using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // You need to add this ypourself if you want to have UI types


public class GameManager : MonoBehaviour {

	public Text player1scoreText;
	public Text player2scoreText;
	public Text playerWinsText;

	public int player1score;
	public int player2score;

	GameObject theBall;

	// Use this for initialization
	void Start ()
	{
		theBall = GameObject.FindGameObjectWithTag ("Ball");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void QuitClicked()
	{
		Application.Quit();
	}

	public void RestartButtonClicked()
	{
		player1score = 0;
		player2score = 0;
		//theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
		theBall.SendMessage("RestartGame", SendMessageOptions.RequireReceiver);
	}

	IEnumerator Wait2SecondsBeforeRestart()
	{
		yield return new WaitForSeconds(2);

		player1scoreText.text = player1score.ToString();
		player2scoreText.text = player2score.ToString();
	
		// Once we have waited for 2 seconds reset the playerWinsText to be inactive and then reset ball.
		playerWinsText.gameObject.SetActive (false);
		//theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
		theBall.SendMessage("RestartGame", SendMessageOptions.RequireReceiver);
	}

	void DisplayWinMessageAndResetScore(string message)
	{
		player1score = 0;
		player2score = 0;

		playerWinsText.gameObject.SetActive (true);
		playerWinsText.text = message;

		// Call our coroutine anything after this line in this function will happen right away
		StartCoroutine(Wait2SecondsBeforeRestart());
	}

	public void Score(string wallID)
	{
		if (wallID == "RightWall") 
		{
			player1score++;
			player1scoreText.text = player1score.ToString();
		} else {
			player2score++;
			player2scoreText.text = player2score.ToString();
		}

		bool won = false;
		// Has anyone lost by 10 points, if so display a message and reset the game
		if (player1score > 10) 
		{
			won = true;
			DisplayWinMessageAndResetScore ("PLAYER ONE WINS");
		} else if (player2score > 10) 
		{
			won = true;
			DisplayWinMessageAndResetScore ("PLAYER TWO WINS");
		}

		if (!won)
		{
			// Sends a message to the Ball object and calls RestartGame on it
			theBall.gameObject.SendMessage("RestartGame", SendMessageOptions.RequireReceiver);
		}
	}
}
