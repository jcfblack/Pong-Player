using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public const int PADDLE_CEILING = 13, PADDLE_FLOOR = -13, OFF = 0;
	public Ball ball;
	public Paddle player1Paddle, player2Paddle;
	public ScoreHandler scoreHandler;
	public EndMessageHandler endMessageHandler;
	bool gameOver;
	bool newPoint;
	public GameObject instructions;

	// Use this for initialization
	void Start ()
	{
		NewGame ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (newPoint && Input.GetKey(KeyCode.Space))		//if the user presses space while the game is over
		{													//a new game will begin
			instructions.SetActive(false);
			ball.Launch();
			newPoint = false;
		}
		else if(Input.GetKey(KeyCode.Escape))
		{
			NewGame();
		}
	}

	void NewGame()
	{
		gameOver = false;
		endMessageHandler.SetDisplay(OFF);
		NewPoint();
		scoreHandler.Reset();
		instructions.SetActive(true);
	}

	public void GameOver(int winningPlayer)
	{
		endMessageHandler.SetDisplay(winningPlayer);
		gameOver = true;
	}

	public void NewPoint()
	{
		newPoint = true;
		ball.Reset();
		player1Paddle.Reset();
		player2Paddle.Reset();
	}

	public bool pointActive
	{
		get
		{
			return !newPoint;
		}
	}
}
