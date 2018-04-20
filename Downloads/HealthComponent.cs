using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; // Required when using UI elements

public class HealthComponent : MonoBehaviour 
{

	public int maxHealth = 100; //max health
	public int currentHealth; //current player health
	//public Slider healthBar; //was for implementing a health bar for later but didn't have the slider

	PlayerMovement playerm; //player movement script set
	bool died; //check if player is dead or not

	// Use this for important initalizations
	void Awake ()
	{
		playerm = GetComponent <PlayerMovement> (); //set as player movement component
		currentHealth = maxHealth; //set current health as max health at start
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	//take damage function
	public void TakenDamage (int amount)
	{		
		currentHealth -= amount;
		//healthBar.value = currentHealth;

		//if health is 0 or below player dies
		if (currentHealth <= 0 && !died) 
		{
			Die ();
		}
	}

	//heal damage function
	public void HealDamage (int amount)
	{
		//if player is below 100 health then you will heal
		if (currentHealth < 100)
		{
			currentHealth += amount;
		}
	}

	//death function for the player
	void Die ()
	{
		died = true; //if player dies then this will be set as true
		playerm.enabled = false; //player can no longer move
	}
}
