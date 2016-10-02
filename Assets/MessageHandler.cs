/* Pong-Player
 * Justin Ferrill
 * jferrill@berklee.edu
 * 
 * This class is used by GameController to display or remove text overlays.
 * 
 */

using UnityEngine;
using System.Collections;

public class MessageHandler : MonoBehaviour
{
	public GameObject player1Victory, player2Victory, instructions;

	public void DisplayVictoryScreen(int player)
	{
		if(player == 0)
		{
			player1Victory.SetActive(false);
			player2Victory.SetActive(false);
		}
		else
		{
			if(player == 1)
			{
				player1Victory.SetActive(true);
				player2Victory.SetActive(false);
			}
			else if(player == 2)
			{
				player1Victory.SetActive(false);
				player2Victory.SetActive(true);
			}
			else
			{
				Debug.Log(player + " is an invalid input for MessageHandler.DisplayVictoryScreen(int player)." +
					" Int value must be 0, 1, or 2.");
			}
		}
	}

	public void DisplayInstructions(bool display)
	{
		instructions.SetActive(display);
	}
}
