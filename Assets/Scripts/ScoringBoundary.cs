/* LMSC_281_Pong-Player
 * Justin Ferrill
 * jferrill@berklee.edu
 * 
 * This class detects when a ball has entered the right or left sides of the screen. It then plays a sound
 * and uses ScoreHandler to give the appropriate player a point. 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class ScoringBoundary : MonoBehaviour
{
	public ScoreHandler scoreHandler;

	void OnTriggerEnter(Collider otherObject)
	{
		if (otherObject.tag.Equals("Ball"))
		{
			gameObject.GetComponent<AudioSource>().Play();

			if (otherObject.bounds.center.x < 0)		//if the collider (which is necessarily the ball) is on the
			{ 											//left side of the screen when it makes contact with the
				scoreHandler.IncrementScore(2);			//scoring boundery, increment player 2's score
			}
			else 										//if the ball is on the right side (or dead center, technically
			{											//but that isn't possible) of the screen when it makes
				scoreHandler.IncrementScore(1);			//contact with the scoring boundery, increment player 1's score
			}
		}
		else
		{
			Debug.Log ("Unknown collider on trigger: " + otherObject.tag);
		}
	}
}
