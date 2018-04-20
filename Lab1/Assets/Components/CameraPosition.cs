using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindWithTag ("Player");
		offset = gameObject.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.transform.position + offset;
	}
}
