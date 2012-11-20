using UnityEngine;
using System.Collections;

class cCurrentRope
{
	public Vector3 ropeVector;	//The Vector of the rope itself
	public Vector3 start;	//The rope's start point (the ropeShotSpot)
	public Vector3 end;		//The rope's end point (the platform)
	public GameObject thePlatform;	//To save the platform the rope is attached to
	public float savedLength;	//The length of the rope when the rope was first established
	public float currentLength;		//The current length of the rope
	public float maxStretch = 5.0f;	// The ammount the rope can stretch (This variable is of little use at the moment)
	public float tensionRatio = 3.0f;	// The ratio the inward and outward forces of the rope will vary by
		
};

	

public class scrShootRope : MonoBehaviour 
{
	private cCurrentRope currentRope = null;	// The instance of the rope
	GameObject player;	//The player
	public GameObject[] arrPlatform;	// array of all the game platforms
	
	Vector3 lineToPlatform;	//dist from player to platform
	Vector3 ropeStartPosition;	// The start position of the ropeShotSpot
	
	private float lineToPlatformLength;//length of the rope
	private float minSwingDistance = 35.0f;	//minimal distance the player needs to be to latch onto a platform
	
	public bool isSwinging = false;	//is the player swinging?
	bool isShootingRope = false;	//is the player shooting their rope?
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		//nothing
	}
	
	
	
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// If the player presses the shoot rope button
		if(Input.GetButtonDown("ShootRope"))
		{
			//If the player is currently swinging from a rope, then stop
			if(currentRope != null)
			{
				isSwinging = false;
				currentRope = null;
				print("let go from rope");
			}
			//else, the player is trying to latch onto a platform
			else
			{
				isShootingRope = true;
				print("shooting rope");
			}
		}
		// else the player is not shooting their rope
		else
		{
			isShootingRope = false;
		}
			
		
		//If the player is shooting their rope
		if(isShootingRope == true)
		{
			CheckForSwingablePlatform();
		}
		//If the player is swinging
		if(isSwinging)
		{
			ApplySwingForces();
		}				
	}
	
	
	
	
	//Check if there are any available platforms to swing from
	void CheckForSwingablePlatform()
	{
				//Get the rope's start position (offset by y + 0.5f)
		ropeStartPosition = transform.position;
		ropeStartPosition.y += 0.5f;
	 	
		//Check through each possible platform
		for(int i = 0; i < arrPlatform.Length; ++i)
		{	
			//Get the length of the vector from the player to the current platform
			lineToPlatform = arrPlatform[i].transform.position - ropeStartPosition;
			lineToPlatformLength = lineToPlatform.magnitude;
		//	lineToPlatformLength = Vector3.Distance(arrPlatform[i].transform.position, ropeStartPosition);
			
			//Check if the player is close enough and below the platform
			if(lineToPlatformLength <= minSwingDistance && ropeStartPosition.y < arrPlatform[i].transform.position.y)
			{
				print("new rope established");
				//The player is now swinging
				isSwinging = true;//toggle
				
				//The rope has already been fired
				isShootingRope = false;
				
				//Establish new rope
				currentRope = new cCurrentRope();
				currentRope.thePlatform = arrPlatform[i];
				currentRope.start = ropeStartPosition;
				currentRope.end = currentRope.thePlatform.transform.position;
				currentRope.ropeVector = currentRope.start - currentRope.end;
				currentRope.currentLength = currentRope.ropeVector.magnitude;
				currentRope.savedLength = currentRope.currentLength;
			
				//Normalize the vector so we can apply our own rope tension
				currentRope.ropeVector.Normalize();
			
				break;	//There is only ever one platform to be attached to at a time, so break from the loop
			}
		}
	}
	
	
	
	
	//Calculate the player's swing force
	void ApplySwingForces()
	{
			
		print("player is swinging");
		
		//To allow the player to jump mind swing
		player = GameObject.FindWithTag("Player");
		player.GetComponent<scrPlayer>().isTouchedGround = true;
		
		//Get the rope's current location and length
		currentRope.start = transform.position;
		currentRope.ropeVector = currentRope.start - currentRope.end;
		currentRope.currentLength = currentRope.ropeVector.magnitude;
				
		//Normalize the vector so we can apply our own rope tension
		currentRope.ropeVector.Normalize();
		
				
		//Draw the rope
		Debug.DrawLine(currentRope.start, currentRope.end, Color.red);	//Draw the rope
		
		//when too far away
		//apply force in
		if(currentRope.currentLength > (currentRope.savedLengt)//currentRope.maxStretch))
		{h + 1)
			currentRope.tensionRatio = currentRope.currentLength * ((currentRope.currentLength - currentRope.savedLength)/2);
			currentRope.ropeVector *= currentRope.tensionRatio;
			transform.parent.parent.parent.rigidbody.AddForce(-currentRope.ropeVector);//force in, attraction
		}
			
		//when too close
		//apply small force away
		if(currentRope.currentLength < (currentRope.savedLength - currentRope.maxStretch))
		{
			currentRope.tensionRatio = currentRope.currentLength * ((currentRope.currentLength - currentRope.savedLength)/4);
			currentRope.ropeVector *= currentRope.tensionRatio;
			transform.parent.parent.parent.rigidbody.AddForce(currentRope.ropeVector);//force out, repulsion
		}	
	}
}

