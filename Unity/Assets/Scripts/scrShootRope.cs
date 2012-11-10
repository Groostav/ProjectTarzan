using UnityEngine;
using System.Collections;

public class scrShootRope : MonoBehaviour 
{

	public GameObject ropePrefab;	// Will instantiate a ropePrefab when the player "ShootRope"s
	GameObject rope;// a clone of the rope
	bool isSwinging = false;//is the player attempting to swing?
	private float minPlatformDistance = 35.0f;	//minimal distane the player needs to be to latch onto a platform
	private float ropeTension = 15.0f; // tension in the rope
	
	public GameObject[] arrPlatform;	// array of all the game platforms

	
	
	
	// Use this for initialization
	void Start () 
	{
		//nothing
	}
	
	
	
	
	// Update is called once per frame
	void Update () 
	{
			//If the player is attempting to swing
		if(isSwinging)
		{	
				//Get the player's start position (offset by y + 0.5f)
			Vector3 ropeStartPosition = transform.position;
			ropeStartPosition.y += 0.5f;

				//Check through each possible platform
			for(int i = 0; i < arrPlatform.Length; ++i)
			{	
					//Get the vector from the player to the current platform
				Vector3 lineBetween = arrPlatform[i].transform.position - ropeStartPosition;
				float lineMagnitude = lineBetween.magnitude;
			//	print (lineMagnitude);	// For checking purposes
				
					//Check if the platform is close enough
				if(lineMagnitude <= minPlatformDistance)
				{
						//Normalize the vector so we can apply our own rope tension
					lineBetween.Normalize();
					Debug.DrawLine(ropeStartPosition, arrPlatform[i].transform.position, Color.red);	//Draw the grappling hook line
						//parent.parent.parent is the player 
					transform.parent.parent.parent.rigidbody.AddForce(lineBetween * ropeTension);	// Apply rope tension
				}

			}	
		}
	}
	
	
	
	
		// Fixed Update is garanteed to be called once per frame
	void FixedUpdate()
	{
			// Two possible buttons the player can press to toggle the grappling hook on and off
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("ShootRope") )
		{
			isSwinging = !isSwinging;//toggle
		}
	}
}
