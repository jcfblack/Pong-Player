/* LMSC_281_Pong-Player
 * Justin Ferrill
 * jferrill@berklee.edu
 * 
 * This class is responsible for handling the start of a new game and each new point. It uses Ball, Paddle
 * and ScoreHandler to reset the appropriate classes when necessary and MessageHandler to display relevant
 * text overlays.
 * 
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public const int OFF = 0;
	public Ball ball;
	public Paddle player1Paddle, player2Paddle;
	public ScoreHandler scoreHandler;
	public MessageHandler messageHandler;
//	bool gameOver;		//not currently used, but could be useful for additional features
	bool pointActive;

	void Start()
	{
		NewGame();
	}

	void Update()
	{
		if(!pointActive && Input.GetKey(KeyCode.Space))			
		{														
			messageHandler.DisplayInstructions(false);
			ball.Launch();
			pointActive = true;
		}
		else if(Input.GetKey(KeyCode.Escape))
		{
			NewGame();
		}
	}

	void NewGame()
	{
//		gameOver = false;
		messageHandler.DisplayVictoryScreen(OFF);
		messageHandler.DisplayInstructions(true);
		scoreHandler.Reset();
		NewPoint();
	}

	public void GameOver(int winningPlayer)
	{
		messageHandler.DisplayVictoryScreen(winningPlayer);
//		gameOver = true;
	}

	public void NewPoint()
	{
		pointActive = false;
		ball.Reset();
		player1Paddle.Reset();
		player2Paddle.Reset();
	}

	public bool IsPointActive()
	{
		return pointActive;
	}
}
