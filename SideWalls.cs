using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

	public GameObject GameManagerObject;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// This gets called when the 2d Collider is triggered by a collision
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if (hitInfo.name == "Ball") 
		{
			string wallName = transform.name;

			// Here we get the script "GameManager" component from the game object to call the score method on it.
			GameManagerObject.GetComponent<GameManager>().Score(wallName);
		}
	}
}
