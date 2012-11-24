using UnityEngine;
using System.Collections;

public class scrRotateCamera : MonoBehaviour 
{
	
	private float rotSpd = 1.0f; //rotation speed per frame
	
	
	
		// Use this for initialization
	void Start()
	{
		//nothing
	}
	
	
		
	// Update is called once per frame
	void Update()
	{
		//nothing
	}
	
	
	
	
		//guarnteed to run each frame
	void FixedUpdate () 
	{		
			// Player vertical camera movement
		if(Input.GetButton("Fire2"))
		{
			Screen.lockCursor = true;	// Lock the cursor to the screen
			float rotX = rotSpd * Input.GetAxis("MouseLookY");
			transform.Rotate(Vector3.right, rotX);	//rotate player around y
		}
		else
		{
			Screen.lockCursor = false;	// Unlock the cursor from the screen
		}
	}
}
