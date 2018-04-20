using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public KeyCode moveForward;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode moveBackward;
    public KeyCode moveJump;
	public Rigidbody rb;

	//allows for ease of changing speed
    public float speed;
	//checks if the player is grounded or not
	public bool onGround;

    // Use this for important initalizations
    void Awake()
    {
        //moveJump = KeyCode.Space;
        rb = GetComponent<Rigidbody>();
		//checking for if player is on the ground
		onGround = true;
    }

	// Use this for initialization
	void Start () 
    {
		
	}
	

	// Update is called once per frame
	void Update () 
    {
        Movement();
        Jump();
	}

    void Jump()
    {
		//checks if player pushed key and the player is on the ground
		if (Input.GetKeyDown(moveJump) && onGround == true)
        {
			//the vector force for jumping
            rb.AddForce(Vector3.up * 500.0f);
			//sets on the ground as false when you are in the air after jumping
			onGround = false;
        }
    }

    void Movement()
    {
        // This if-statement moves the player forward
        if (Input.GetKey(moveForward))
        {
            rb.velocity = Vector3.forward * speed;
            // Use this for simple objects that don't require a lot of detail
            //transform.Translate(Vector3.forward); // (0, 0, 1)
        }
        if (Input.GetKey(moveLeft))
        {
            rb.velocity = Vector3.left * speed;
            //transform.Translate(Vector3.left); // (-1, 0, 0)
        }
        if (Input.GetKey(moveRight))
        {
            rb.velocity = Vector3.right * speed;
            //transform.Translate(Vector3.right); // (1, 0, 0)
        }
        if (Input.GetKey(moveBackward))
        {
            rb.velocity = Vector3.back * speed;
            //transform.Translate(Vector3.back); // (0, 0, 1)
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
		//makes the on the ground to true for the player then adds a jump force
		onGround = true;
		if (collision.gameObject == GameObject.FindWithTag("Trampoline")) 
		{
			//trampoline effect force upwards
			rb.AddForce(Vector3.up * 500.0f);
		}

		//respawn if the player falls into the out of bounds grid
		if (collision.gameObject == GameObject.FindWithTag ("GameArea")) 
		{
			//respawns player at the vector position
			transform.position = new Vector3(0, 1, 0);
		}
    }

	/*
    void OnCollisionStay(Collision collision)
    {
        
    }
	
    void OnCollisionExit(Collision collision)
    {		

    }*/
		

}
