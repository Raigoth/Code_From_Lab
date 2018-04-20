using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField] private KeyCode N;
	[SerializeField] private KeyCode S;
	[SerializeField] private KeyCode W;
	[SerializeField] private KeyCode E;
	[SerializeField] private KeyCode J;

	[SerializeField] private Rigidbody rg;

	[SerializeField] private float speed;
	[SerializeField] private bool onGround;

	// Use this for initialization
	void Awake () {
		rg = GetComponent<Rigidbody> ();
		onGround = true;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Jump ();
	}

	void Move() {
		if(Input.GetKey(N))	{
			if(rg.velocity.magnitude < 5.0f) {
				rg.velocity += Vector3.forward * speed;
			}
		}
		else if(Input.GetKey(S)) {
			if(rg.velocity.magnitude < 5.0f) {
				rg.velocity += Vector3.back * speed;
			}
		}
		else if(Input.GetKey(E)) {
			if(rg.velocity.magnitude < 5.0f) {
				rg.velocity += Vector3.right * speed;
			}
		}
		else if(Input.GetKey(W)) {
			if(rg.velocity.magnitude < 5.0f) {
				rg.velocity += Vector3.left * speed;
			}
		}
	}

	void Jump() {
		if (Input.GetKeyDown(J) && onGround == true) {
			rg.AddForce(Vector3.up * 500.0f);
			onGround = false;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		onGround = true;
		if (collision.gameObject == GameObject.FindWithTag("GameArea")) {
			transform.position = new Vector3(3.0f,1.0f,-3.0f);
		}
	}

	void Shoot() {
		var minion = (GameObject)Instantiate (
			             bulletPrefab,
			             bulletSpawn.position,
			             bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody> ().velocitry = bullet.transform.forward * 6;
		Destroy(bullet. 2.0f);
	}

}
