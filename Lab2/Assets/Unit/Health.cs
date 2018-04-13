using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
	float hitPoints;
	float maxHitPoints;
	float hitPointRegeneration;
	float hitPointRecoveryTime;
	Coroutine routine;

	// Use this for initialization
	void Awake() 
	{
		Unit unitInfo = gameObject.GetComponent<Unit>();
		maxHitPoints = unitInfo.HitPoint;
		hitPoints = maxHitPoints;
		hitPointRegeneration = unitInfo.HitPointRegeneration;
		hitPointRecoveryTime = unitInfo.HitPointRecoveryTime;
	}

	public float HitPoints
	{
		get { return hitPoints; }
		set 
		{
			hitPoints += value;
			if (value < 0)
			{
				Animator animation = gameObject.GetComponent<Animator>();

				if (hitPoints > 0)
				{
					animation.SetTrigger("getHit");
				}
				else
				{
					gameObject.GetComponent<Combat>().enabled = false;
					gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject.GetComponent<CapsuleCollider>().enabled = false;

					animation.SetTrigger("isDead");

					routine = StartCoroutine(Death(5.0f));
				}
			}
			if (hitPoints > maxHitPoints)
			{
				hitPoints = maxHitPoints;
			}
		}
	}

	IEnumerator RegenerateHitPoints()
	{
		HitPoints = hitPointRegeneration;
		yield return new WaitForSeconds(hitPointRecoveryTime);
		routine = StartCoroutine(RegenerateHitPoints());
	}

	IEnumerator Death(float timeToDie)
	{
		yield return new WaitForSeconds(timeToDie);
		Destroy(gameObject);
	}

	public void Stop()
	{
		StopCoroutine(routine);
	}
}
