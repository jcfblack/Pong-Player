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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
