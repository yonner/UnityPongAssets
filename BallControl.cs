using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 vel;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();

		// Calls the GoBall method after 2 second delay
		Invoke("GoBall", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GoBall()
	{
		// Flip a coin and either add force to the ball to make it go left or right
		float rand = Random.Range(0, 2);

		if(rand < 1)
		{
			rb2d.AddForce(new Vector2(20, -15));
		} else {
			rb2d.AddForce(new Vector2(-20, -15));
		}
	}

	void ResetBall()
	{
		vel = Vector2.zero;
		rb2d.velocity = vel;
		transform.position = Vector2.zero;
	}

	void RestartGame()
	{
		ResetBall();
		Invoke("GoBall", 1);
	}

	// This is called when we detect any collision with a player object
	void OnCollisionEnter2D (Collision2D coll)
	{
		if(coll.collider.CompareTag("Player"))
		{
			vel.x = rb2d.velocity.x;
			vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
			rb2d.velocity = vel;
		}
	}

}
