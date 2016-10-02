/* Pong-Player
 * Justin Ferrill
 * jferrill@berklee.edu
 * 
 * This interface is implemented by Paddle and SolidBounder to indicate that if Ball collides with them, 
 * it needs to recalculate its velocity
 * 
 */

using UnityEngine;
using System.Collections;

public interface SolidObject
{
	Vector3 GetMomentum();

	string GetSlope();
}
