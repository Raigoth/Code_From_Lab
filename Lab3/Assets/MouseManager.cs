using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseManager:MonoBehaviour 
{

	public static MouseManager Current;

	public MouseManager()
	{
		Current = this;
	}
	Vector3 mousePosition1;
	Vector3 mousePosition2;
	float lastClickTime;
	[SerializeField] float catchTime;


	[SerializeField] List<Unit> selections = new List<Unit>();

	void Update() 
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			if (Input.GetMouseButtonDown(0))
			{
				foreach (Unit unit in selections)
				{
					if (unit != null)
					{
						unit.Deselect();
					}
				}
				selections.Clear();

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					Unit unit = hit.collider.gameObject.GetComponent<Unit>();
					if (Time.time - lastClickTime < catchTime)
					{
						if (unit != null)
						{
							foreach (Unit u in FindObjectOfType<Unit>())
							{
								if (unit.name == u.name)
								{
									selections.Add(u);
									u.Select();
								}
							}
						}
						isDragSelection = false;
						return;
					}
					else
					{
						if (unit != null)
						{
							
						}
						lastClickTime = Time.time;
						mousePosition1 = Input.mousePosition;
					}
					isDragSelection = true;
				}
			}
		}
	}

	public List<Unit> Selections
	{
		get{ return selections; }
		set{ selections = value; }
	}

	bool isDragSelection = false;

	void OnGUI()
	{
		if (isDragSelection)
		{
			Rect rect = GetScreenRectangle(mousePosition1, Input.mousePosition);
			DrawScreenRectangle(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
			DrawScreenRectangleBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
		}
	}

	public static class Utils
	{
		static Texture2D texture;
		public static Texture2D Texture
		{
			get
			{
				if (texture == null)
				{
					texture = new Texture2D(1, 1);
					texture.SetPixel(0, 0, Color.green);
					texture.Apply();
				}
				return texture;
			}
		}
	}

	public static Rect GetScreenRectangle(Vector3 screenPosition1, Vector3 screenPosition2)
	{
		screenPosition1.y = Screen.height - screenPosition1.y;
		screenPosition2.y = Screen.height - screenPosition2.y;
		Vector3 corner1 = Vector3.Min(screenPosition1, screenPosition2);
		Vector3 corner2 = Vector3.Max(screenPosition1, screenPosition2);

		return Rect.MinMaxRect(corner1.x, corner1.y, corner2.x, corner2.y);
	}

	public static void DrawScreenRectangle(Rect rect, Color color)
	{
		GUI.color = color;
		GUI.DrawTexture(rect, Texture2D.whiteTexture);
		GUI.color = Color.green;
	}

	public static void DrawScreenRectangleBorder(Rect rect, float thickness, Color color)
	{
		DrawScreenRectangle(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
		DrawScreenRectangle(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
		DrawScreenRectangle(new Rect(rect.xMax - thickness, rect.yMin, rect.width, thickness), color);
		DrawScreenRectangle(new Rect(rect.xMin, rect.yMax - thickness, thickness, rect.height), color);
	}
}
