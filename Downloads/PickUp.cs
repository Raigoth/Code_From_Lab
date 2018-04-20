using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour 
{
    List<GameObject> PickUps = new List<GameObject>();
	public int heal = 25; //when picked up player heals

	GameObject player; //player object for ease
	HealthComponent hp; //health script

	// Use this for important initalizations
	void Awake ()
	{
		//player object set as player
		player = GameObject.FindGameObjectWithTag ("Player");
		//health of player set as hp
		hp = player.GetComponent <HealthComponent> ();
	}

    // Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    void LateUpdate()
    {
        // This List will gather all of the GameObjects that are tagged in a list
		PickUps.AddRange(GameObject.FindGameObjectsWithTag("PickUp"));
		//movement of the pickup
        gameObject.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
			//destroys pickup and player gains 25 health
            Destroy(gameObject);
			hp.HealDamage (heal);
        }
    }

    /* In order for OnTrigger functions to work, they need a Collider Component and a Collider parameter
    void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        
    }
    */
}
