/* Pong-Player
 * Justin Ferrill
 * jferrill@berklee.edu
 * 
 * This class implements SolidObject to indicate to Ball that it should recalculate velocity when it collides
 * with a Paddle.
 * 
 */

using UnityEngine;
using System.Collections;

public class SolidBoundary : MonoBehaviour, SolidObject
{
	public Vector3 GetMomentum()
	{
		return new Vector3 (0, 0, 0);
	}

	public string GetSlope()
	{
		return "horizontal";
	}
}
