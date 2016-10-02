using UnityEngine;
using System.Collections;

public class ScoringBoundary : MonoBehaviour
{
	public ScoreHandler scoreHandler;

	void OnTriggerEnter(Collider otherObject)
	{
		if (otherObject.tag.Equals("Ball"))
		{
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
