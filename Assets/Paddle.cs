using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour, SolidObject
{
	Vector3 myMomentum;
	public const float PADDLE_SPEED = 25.0f;
	public const float MAX_MOMENTUM = 15.0f;
	public string controlUp, controlDown;
	Vector3 startPosition;
	public GameController gameController;


	// Use this for initialization
	void Start()
	{
		myMomentum = new Vector3 (0, 0, 0);
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (gameController.pointActive)
		{
			MovePaddle();
		}
	}

	void MovePaddle()
	{
		if (Input.GetKey (controlUp) && Input.GetKey (controlDown)) 
		{ 
			ResetMomentum ();
		} 
		else if(Input.GetKey (controlUp)) 
		{
			if (transform.position.y >= GameController.PADDLE_CEILING)			//stops paddle from ascending off the screen
			{
				transform.position = new Vector3 (startPosition.x, GameController.PADDLE_CEILING, startPosition.y);
			}
			if (myMomentum.y < 0)
			{
				ResetMomentum (); //If momentum was going down, while the paddle is going up, reset momentum value
			}
			else if (Mathf.Abs (myMomentum.y) >= MAX_MOMENTUM) //don't let momentum go higher than max
			{ 
				myMomentum.y = MAX_MOMENTUM;
			}
			else 
			{
				addUpwardsMomentum(); //increments momentum while up is pressed. The longer the Paddle has been moving, 
			}
			transform.Translate (Vector3.up * PADDLE_SPEED * Time.deltaTime);
		}
		else if (Input.GetKey (controlDown)) 
		{
			if (transform.position.y <= GameController.PADDLE_FLOOR)
			{
				transform.position = new Vector3 (startPosition.x, GameController.PADDLE_FLOOR, startPosition.y);
			}
			if (myMomentum.y > 0) 
			{
				ResetMomentum(); //If momentum is up while paddle is moving down, reset momentum
			} 
			else if(Mathf.Abs(myMomentum.y) >= MAX_MOMENTUM) //don't let momentum go higher than max
			{
				myMomentum.y = MAX_MOMENTUM;
			}
			else 
			{
				addDownwardsMomentum (); //decrements momentum while down is pressed
			}
			transform.Translate (Vector3.down * PADDLE_SPEED * Time.deltaTime);
		}
		else
		{
			ResetMomentum(); //if no input, reset momentum
		}
	}

	public void Reset()
	{
		transform.position = startPosition;
	}

	public void addUpwardsMomentum()
	{
		myMomentum.y += 1.5F;
	}

	public void addDownwardsMomentum()
	{
		myMomentum.y -= 1.5F;
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
