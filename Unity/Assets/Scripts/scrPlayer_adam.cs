using UnityEngine;
using System.Collections;


public class scrPlayer : MonoBehaviour
{
	public int hp = 200;
	public float horizontalSpeed = 0.2f;//strafe speed
	public float verticalSpeed = 0.5f;//forward back speed
	public float rotateSpeed = 2.0f;//rotation speed
	float jumpForce = 500;//jump force
	float fallForce = 1;
	bool isGrounded = true;
	bool inAir = false;
	
	
	//## player 3d model variables
	/*
	public GameObject playerModel;
	private bool isMoving;
	private bool isAttacking;
	*/
	
	
	// Use this for initialization
	void Start ()
	{		
		//## player 3d model
		//isAttacking = false;
		//isMoving = false;		
		bool inAir = false;
	}
	
	
	void FixedUpdate ()
	{
		float h = horizontalSpeed * Input.GetAxis ("Horizontal");
		float v = verticalSpeed * Input.GetAxis ("Vertical");
		float r = rotateSpeed * Input.GetAxis ("Rotate");
		//float j = jumpForce * Input...
		
		
		//## player 3d model
		/*
		isMoving = (h > 0.01f) || (h < -0.01f) || (v > 0.01f) || (v < -0.01f);//determine if the player is moving
		
		//if player isn't attacking, then he can move or idle
		if (!isAttacking) 
		{
			if (isMoving) 
			{
				playerModel.animation.CrossFade ("walk");
			}
			else 
			{
				playerModel.animation.CrossFade ("idle");
			}
		}
		
		//if user wants player to attack
		//and the player isn't currently moving
		if (Input.GetButtonDown ("Fire1") && !isMoving)
		{
			isAttacking = true;
			playerModel.animation.CrossFade ("attack");
			print ("attack ON");
		}		
		
		//when the attack animation has stopped playing
		if (isAttacking && !playerModel.animation.isPlaying)
		{
			isAttacking = false;
			print ("attack OFF");
		}
		*/
		
		transform.Translate (h, 0, v);//movement in X,Z
		transform.Rotate (Vector3.up, r);//rotation around player's Y
		
		if(Input.GetButtonDown("Jump") && isGrounded == true)//jump up on player's Y
		{
			rigidbody.AddForce(jumpForce * (h * 5) ,jumpForce * fallForce, jumpForce * (v * 10));//push the player 		
			fallForce = player.rigidbody.velocity;
			print (fallForce);
		}
		
	}
	void OnCollisionStay(Collision hit)
	{
		//##jumping
		//
		//look at the array of contact points
		//that are coming from the hit object
		foreach( ContactPoint contact in hit.contacts)
		{
			//,,print ("contact found");
			//check if the surface of what we're on can be jumped off
			//ie. it's less than this max degrees to vertical
			//
			//Vector3.Angle() returns a float for the degrees between 2 vectors
			//
			//NOTE: we're looking at the normal to the contact!... eg. it could
			//be perpendicular to the plane/ground that we're on
			if(Vector3.Angle(contact.normal, Vector3.up) < 35)
			{
				isGrounded = true;//player is grounded, and therefore can jump again
				//print ("grounded");
				return;//stop looking at contact points bc we know we're grounded
			}
		}
	}
	



	void OnCollisionExit()
	{
		//##jumping
		isGrounded = false;//player isn't grounded bc they're in the air
		//print ("not grounded");
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		if (0 > hp) 
		{
			hp = 0;
			Debug.Log ("You Dead!");
		}
	
	}
	
	
	//graphical user interface output
	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 150, 100), "HP: " + hp);
	}
}
