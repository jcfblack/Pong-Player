﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	Vector3 myVelocity, startPosition, startVelocity, mySpin;
	public const float START_SPEED = 20.0F, SPEED_REDUCTION_RATIO = 0.85F;

	// Use this for initialization
	void Start()
	{
		myVelocity = mySpin = startVelocity = new Vector3(0, 0, 0);
		startPosition = transform.position;
	}

	void Update()
	{
		{
			transform.Translate(myVelocity * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		SolidObject mySolidObject = other.gameObject.GetComponent<SolidObject> ();

		//no action if triggered by a non-SolidObject
		if(mySolidObject == null)
		{
		}
		else
		{
			//applies spin to ball velocity
			if(mySolidObject.GetSlope() == "vertical")
			{
				myVelocity.x *= -1;								//reflect momentum against vertical surface
				myVelocity.y += mySpin.y;						//apply spin
				myVelocity += mySolidObject.GetMomentum();		//apply momentum from SolidObject (necessarily a paddle)
			}
			else if(mySolidObject.GetSlope() == "horizontal")
			{
				myVelocity.y *= -1;								//reflect momentum against horizontal surface
				if(mySpin.magnitude == 0)
				{
				}
				else if((mySpin.x > 0 && mySpin.y > 0) ||			//if paddle and ball were moving in the same y direction at the 
						(mySpin.x < 0 && mySpin.y < 0))				//impact previous to this one, top spin is indicated, meaning 
				{													//the ball should go faster along the x coordinate on this bounce
					if(myVelocity.x < 0)
					{												
						myVelocity.x -= Mathf.Abs(mySpin.y);		
					}
					else if(myVelocity.x > 0)						
					{												
						myVelocity.x += Mathf.Abs(mySpin.y);
					}
				}
				else
				{
					if(myVelocity.x < 0)
					{												//opposite y axis directions indicates backspin
						myVelocity.x += Mathf.Abs(mySpin.y);		//so the x value is reduced in magnitude
					}
					else if(myVelocity.x > 0)
					{
						myVelocity.x -= Mathf.Abs(mySpin.y);
					}
				}
			}//applies spin to ball velocity
				
			//applies SolidObject momentum to ball spin for next collision
			if(mySolidObject.GetMomentum().magnitude == 0.0f)
			{
				mySpin = new Vector3(0, 0, 0);
			}
			else 
			{
				mySpin.x = myVelocity.y;
				mySpin.y = mySolidObject.GetMomentum ().y;
			}//applies SolidObject momentum to ball spin for next collision

			if(ballSpeed > START_SPEED)
			{
				myVelocity.x *= SPEED_REDUCTION_RATIO + .05f;	//helps correct ball's tendency to ricochet annoyingly between the ceiling and floor
				myVelocity.y *= SPEED_REDUCTION_RATIO;
			}
		}
	}

	Vector3 GetRandomVelocity(float magnitude)
	{
		Vector3 randomVelocity;
		do
		{
			randomVelocity = Random.insideUnitCircle.normalized * magnitude;
		} while(Vector3.Angle(randomVelocity, transform.up) <= 30 ||		//ensures that the randomVelocity doesn't point too close to 
			Vector3.Angle(randomVelocity, transform.up * -1) <= 30 ||		//perpendicular with walls or paddles
			Vector3.Angle(randomVelocity, transform.right) <=10 ||			
			Vector3.Angle(randomVelocity, transform.right * -1) <= 10); 
		return randomVelocity;							//returns random Vector3, with z component = 0 and magnitude "magnitude"
	}

	public float ballSpeed
	{
		get
		{ 
			return myVelocity.magnitude;
		}
	}

	public void Reset() //position goes back to center, velocity and spin reset to 0
	{
		transform.position = startPosition;
		myVelocity = startVelocity;
		mySpin = startVelocity;
	}

	public void Launch()
	{
		myVelocity = GetRandomVelocity (START_SPEED);	//launches the ball at a (mostly) random angle
	}
}