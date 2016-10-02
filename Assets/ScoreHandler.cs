using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour
{
	public int player1Score, player2Score;
	public Text player1ScoreDisplay, player2ScoreDisplay;
	public GameController gameController;

	// Use this for initialization
	void Start()
	{
		player1Score = player2Score = 0;
		player1ScoreDisplay = GameObject.Find ("Player1 Score").GetComponent<Text> ();
		player2ScoreDisplay = GameObject.Find ("Player2 Score").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void IncrementScore(int playerNumber) //returns true if and only if a player has won, causing the game to end
	{
		bool gameOver = false;
		if (playerNumber == 1)
		{
			player1Score++;
			UpdateScoreDisplay();
			if (player1Score >= 11 && player2Score <= player1Score - 2)
			{
				gameOver = true;
			}
			else
			{
				gameOver = false;
			}	
		}
		else if (playerNumber == 2)
		{
			player2Score++;
			UpdateScoreDisplay();
			if (player2Score >= 11 && player1Score <= player2Score - 2)
			{
				gameOver = true;
			}
			else
			{
				gameOver = false;
			}	
		}
		else
		{
			Debug.Log("Cannot increment score; " + playerNumber + " is an invalid Player number.");
		}
		if(gameOver)
		{
			gameController.GameOver(playerNumber);
		}
		else
		{
			gameController.NewPoint();
		}
	}

	public void UpdateScoreDisplay()
	{
		player1ScoreDisplay.text = player1Score.ToString();
		player2ScoreDisplay.text = player2Score.ToString();
	}

	public void Reset()
	{
		player1Score = player2Score = 0;
		UpdateScoreDisplay();
	}
}
