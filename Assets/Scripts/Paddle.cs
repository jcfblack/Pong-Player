/* LMSC_281_Pong-Player
 * Justin Ferrill
 * jferrill@berklee.edu
 * 
 * This class handles player input for moving the Paddles and implements SolidObject to indicate to Ball
 * that it should recalculate velocity when it collides with a Paddle.
 * 
 * It also keeps track of keeps track of Paddle.myMomentum. myMomentum is a measure of how long the paddle has
 * been moving in the direction it's currently moving. Positive myMomentum is consecutivie frames on the positive
 * y axis, and negative myMomentum is consecutive frames on the negative y axis. 
 * 
 * It is used is recorded by Ball.mySpin to help calculate collisions
 * 
 */

using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour, SolidObject
{
	Vector3 myMomentum;
	public const int CEILING = 13, FLOOR = -13, MAX_MOMENTUM = 10, PADDLE_SPEED = 25;
	public string controlUp, controlDown;
	public Vector3 startPosition;
	public GameController gameController;

	void Start()
	{
		startPosition = transform.position;
		myMomentum = new Vector3(0, 0, 0);
	}

	void Update()
	{
		if(gameController.IsPointActive())
		{
			MovePaddle();
		}
	}

	void MovePaddle()
	{
		if (Input.GetKey(controlUp) && Input.GetKey(controlDown)) 
		{ 
			ResetMomentum();
		} 
		else if(Input.GetKey(controlUp)) 
		{
			if(transform.position.y >= CEILING)			
			{
				transform.position = new Vector3(startPosition.x, CEILING, startPosition.y);
			}
			if(myMomentum.y < 0)
			{
				ResetMomentum();		//if momentum was going the opposite direction, reset momentum					
			}
			else if (Mathf.Abs (myMomentum.y) >= MAX_MOMENTUM)
			{ 
				myMomentum.y = MAX_MOMENTUM;
			}
			else 
			{
				addUpwardsMomentum();
			}
			transform.Translate (Vector3.up * PADDLE_SPEED * Time.deltaTime);
		}
		else if(Input.GetKey(controlDown)) 
		{
			if(transform.position.y <= FLOOR)
			{
				transform.position = new Vector3(startPosition.x, FLOOR, startPosition.y);
			}
			if(myMomentum.y > 0) 	
			{
				ResetMomentum();		//if momentum was going the opposite direction, reset momentum
			} 
			else if(Mathf.Abs(myMomentum.y) >= MAX_MOMENTUM)
			{
				myMomentum.y = MAX_MOMENTUM;
			}
			else 
			{
				addDownwardsMomentum();
			}
			transform.Translate(Vector3.down * PADDLE_SPEED * Time.deltaTime);
		}
		else
		{
			ResetMomentum(); 	//if paddle is not moving, reset momentum
		}
	}

	public void Reset()
	{
		transform.position = startPosition;
	}

	public void addUpwardsMomentum()
	{
		myMomentum.y++;
	}

	public void addDownwardsMomentum()
	{
		myMomentum.y--;
	}

	public void ResetMomentum()
	{
		myMomentum = new Vector3(0, 0, 0);
	}

	public Vector3 GetMomentum()
	{
		return myMomentum;
	}

	public string GetSlope()
	{
		return "vertical";
	}
}
