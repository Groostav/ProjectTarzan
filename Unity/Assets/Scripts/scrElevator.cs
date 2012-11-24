using UnityEngine;
using System.Collections;

public class scrElevator : MonoBehaviour 
{
	private float elevatorSpeed = 0.1f;	//speed and direction of the elevator
	private bool isGoingUp = true;		// determine which direction the speed is going
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		//nothing
	}
	
	
	
	
	// Update is called once per frame
	void Update () 
	{
			
		if(!isGoingUp && transform.position.y < -20.0f)  
		{
			isGoingUp = true;
			elevatorSpeed *= -1.0f;
		}
		else if(isGoingUp && transform.position.y > 0.0f)
		{
			isGoingUp = false;
			elevatorSpeed *= -1.0f;
		}
		
		
			//Move the elevator in the current direction
		transform.Translate(0.0f, elevatorSpeed, 0.0f);
	}
}
