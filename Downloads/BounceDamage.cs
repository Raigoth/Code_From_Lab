using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDamage : MonoBehaviour 
{
	//everytime player bounces 25 damage is done
	public int dmg = 25;

	GameObject player; //player object for ease
	HealthComponent hp; //health script

	// Use this for important initalizations
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player"); //sets player game object
		hp = player.GetComponent <HealthComponent> (); //sets to player health
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//when a player or enemy hits the trampoline they take damage
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject == player)
		{
			//player takes 25 health
			hp.TakenDamage (dmg);
		}	
	}
}
