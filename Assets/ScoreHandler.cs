/* Pong-Player
 * Justin Ferrill
 * jferrill@berklee.edu
 * 
 * This class manages incrementing and displaying player scores and tells GameController whether it was a 
 * game winning point or if it needs to set up the next one.
 * 
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour
{
	public int player1Score, player2Score;
	public Text player1ScoreDisplay, player2ScoreDisplay;
	public GameController gameController;

	void Start()
	{
		player1Score = player2Score = 0;
	}

	public void IncrementScore(int playerNumber)
	{
		bool gameOver = false;

		if(playerNumber == 1)
		{
			player1Score++;
			UpdateScoreDisplay();
			if(player1Score >= 11 && player2Score <= player1Score - 2)		//evaluates for win condition
			{
				gameOver = true;
			}
			else
			{
				gameOver = false;
			}	
		}
		else if(playerNumber == 2)
		{
			player2Score++;
			UpdateScoreDisplay();
			if(player2Score >= 11 && player1Score <= player2Score - 2)		//evaluates for win condition
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
