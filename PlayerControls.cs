using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	/*
	 * The next few lines are variables we need to write ourselves. 
	 * The first two lines we add will denote the keys that we’ll press to move the paddles (W goes up, S goes down),
	 * and the next one is the speed of the paddle. The ‘boundY’ variable is the highest position that we want our paddle 
	 * to go. This keeps it from moving off the edges of the screen. The last variable is a reference to our Rigidbody that we’ll use later.
	 */

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed = 10.0f;
	public float boundY = 2.25f;
	private Rigidbody2D rb2d;

	/*
	 * Start() is a function that is called when we first launch our game. We’ll use it to do some initial setup, such as setting up our Rigidbody2D:
	 */

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	/*
	 * Update() is a function that is called once per frame. 
	 * We’ll use it to tell us what button is being pressed, and then move the paddle accordingly, or, 
	 * if no button is pressed, keep the paddle still. Lastly we’ll bound the paddle vertically between 
	 * +boundY and -boundY, which will keep it inside the game screen at all times.
	 */ 

	// Update is called once per frame
	void Update () 
	{
		var vel = rb2d.velocity;
		if (Input.GetKey(moveUp)) 
		{
			vel.y = speed;
		}
		else if (Input.GetKey(moveDown))
		{
			vel.y = -speed;
		}
		else if (!Input.anyKey)
		{
			vel.y = 0;
		}

		rb2d.velocity = vel;

		// Stop the paddle from going of the top and bottom of the screen
		var pos = transform.position;
		if (pos.y > boundY)
		{
			pos.y = boundY;
		}
		else if (pos.y < -boundY)
		{
			pos.y = -boundY;
		}
		transform.position = pos;
	}
}
