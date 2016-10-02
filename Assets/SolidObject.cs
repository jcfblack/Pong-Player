using UnityEngine;
using System.Collections;

public interface SolidObject
{
	Vector3 GetMomentum();

	string GetSlope();

//	void OnTriggerEnter(Collider other)
//	{
//		if (gameObject.tag == "Paddle")
//		{
//			ball.velocity = new Vector3 (ball.velocity.x * -1, ball.velocity.y + ball.spin.y, ball.velocity.z); //reflects ball velocity against a vertical axis. If the previously contacted SolidObject was a moving paddle, spin is accounted for by directly transferring that momentum
//			ball.velocity += myVelocity;	//add surface momentum directly (if paddle moves opposite y direction from ball, this will reduce ball speed
//		}
//		else if (gameObject.tag == "Wall")
//		{
//			ball.velocity = new Vector3 (ball.velocity.x, ball.velocity.y * -1, ball.velocity.z);	//reflects ball velocity against horizontal axis
//			if (ball.spin.magnitude == 0.0F)
//			{
//			}
//			else if (ball.spin.x > 0 && ball.spin.y > 0			//if the previous ball velocity and surface velocity are in the same direction y 
//			    || ball.spin.x < 0 && ball.spin.x < 0) 		//this indicates backspin, which reduces the xVelocity
//			{
//				if (ball.velocity.x < 0)	//when x is negative, x is lowered by magnitude of ballspinYVelocity
//				{
//					ball.velocity = new Vector3 (ball.velocity.x - Mathf.Abs (ball.spin.y), ball.velocity.y);
//				} 
//				else 						//raised when x is positive
//				{
//					ball.velocity = new Vector3 (ball.velocity.x + Mathf.Abs (ball.spin.y), ball.velocity.y, ball.velocity.z);
//				}
//			} 
//			else 							//previous ball velocity and surface are contrary, indicating topspin
//			{
//				if (ball.velocity.x < 0)	//to reduce x magnitude, add when negative
//				{						
//					ball.velocity = new Vector3 (ball.velocity.x + Mathf.Abs (ball.spin.y), ball.velocity.y, ball.velocity.z);
//				}
//				else 						//subtract when positive
//				{
//					ball.velocity = new Vector3 (ball.velocity.x - Mathf.Abs (ball.spin.y), ball.velocity.y, ball.velocity.z);
//				}
//			}			
//		}
//		else 
//		{
//			//
//		}
//		if (velocity.y == 0.0f) 
//		{
//			ball.spin = notMoving;		//reset spin if there's no spin to be applied
////			Debug.Log("Ball speed reset");
//		} 
//		else 
//		{
//			ball.spin = new Vector3 (ball.velocity.y, myVelocity.y * (float) 3/4, 0); //spin stores the yVelocities of the ball and the surface at point of contact. this will be incorporated into the next collision
////			Debug.Log("Set ball.spin to " + ball.spin);
//		}
//			
////		}
//		if(ball.ballSpeed > Ball.START_SPEED) //if the ball is moving faster than it started, slow it down a little bit. reduces vertical velocity more than horizontal to keep the ball from zigzagging annoyingly during play
//		{
//			
//		}
//	}
}
