using UnityEngine;
using System.Collections;

public class EndMessageHandler : MonoBehaviour
{
	public GameObject player1Victory, player2Victory;

	public void SetDisplay(int player)
	{
		if(player == 0)
		{
			gameObject.SetActive(false);
		}
		else
		{
			gameObject.SetActive(true);
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
				Debug.Log(player + " is an invalid input for EndMessageHandler.SetDisplay(int player). Int value must be 0, 1, or 2.");
			}
		}
	}
}
