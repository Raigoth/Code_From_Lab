using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour 
{
	Player player;
	bool isAttacking;
	int damage;
	int damageAir;
	float range;
	float rangeAir;
	float rate;
	float rateAir;
	Coroutine routine;
	GameObject target;
	[SerializeField] GameObject projectile;

	void Awake()
	{
		Unit unit = gameObject.GetComponent<Unit>();
		damage = unit.AttackGround;
		damageAir = unit.AttackAir;
		range = unit.AttackRange;
		rangeAir = unit.AttackRangeAir;
		rate = unit.AttackSpeed;
		rateAir = unit.AttackSpeedAir;
		SphereCollider collider = gameObject.GetComponent<SphereCollider>();
		collider.radius = range;
		collider.center = gameObject.GetComponent<CapsuleCollider>().center;
		isAttacking = false;
	}

	void Start()
	{
		player = gameObject.GetComponent<Player>();
	}

	public void Aggression(GameObject unit)
	{
		target = unit;

		if (Vector3.Distance(gameObject.transform.position, target.transform.position))
		{
			routine = StartCoroutine(Attacking());
		}
		else
		{
			isAttacking = false;
			gameObject.GetComponent<Movement>().SendToTarget(target.transform.position);
		}
	}

	IEnumerator Attacking() 
	{
		Unit otherUnit = target.GetComponent<Unit>();

		if (otherUnit.IsFlying && damageAir == 0)
		{
			Stop();
			yield break;
		}
		//else if (gameObject.GetComponent<Unit>().AttackType == Unit.Attack.Siege && otherUnit.tag != "Building")
		//{
		//}

		Vector3 direction = (target.transform.position - gameObject.transform.position).normalized;
		direction = new Vector3(direction.x, 0.0f, direction.z);
		Quaternion lookRotation = Quaternion.LookRotation(direction);

	}

	void OnTriggerEnter(Collider unit)
	{
		if (unit.gameObject == target && !unit.isTrigger)
		{
			routine = StartCoroutine(Attacking());
			gameObject.GetComponent<Movement>().Stop();
		}
	}
}
