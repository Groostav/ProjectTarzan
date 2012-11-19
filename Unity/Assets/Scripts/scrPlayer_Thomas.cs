using UnityEngine;
using System.Collections;

public class scrPlayer : MonoBehaviour 
{		
	public Texture2D textureWin;	// Victory Image
	public const float buffSpace = 10.0f; // space around GUI stuff, so it's not just against the edge 
	private const int textureWinWidth = 128;	// texture width of win message
	private const int textureWinHeight = 128;	// texture height of win message
	private bool isVictory = false;		// victory condition

	private float strafeSpd = 0.6f;	//horizontal strafe speed
	private float fbSpd = 0.6f;	//forward backwards speed	
	private float rotSpd = 2.0f; //rotation speed per frame
	private float jumpForce = 2000.0f; // jump force
	private const float gravityForce = -50.0f;		//gravity force
	
	public bool isTouchedGround = false;	//Has the player touched the ground since his last jump?
	
	GameObject ropeShotSpot;	// A handel to the rope's shot spot
	
	
	// Use this for initialization
	void Start () 
	{	
		//nothing
		//Physics.gravity = Vector3.zero;
	}
	
	
	
	
	// Update is called once per frame
	void Update () 
	{
		//nothing
	}
	
	
	
	
	//guarnteed to run each frame
	void FixedUpdate()
	{

		rigidbody.AddForce(0.0f, gravityForce, 0.0f);//apply gravity down

				//player directional movement
		float s = strafeSpd * Input.GetAxis("Strafe");
		float fb = fbSpd * Input.GetAxis("ForwardBack");
		transform.Translate(s, 0, fb);	//movement x, and z

				
			//Player jump ability (has to have touched the ground since last jump)
		if(Input.GetButtonDown("Jump") && isTouchedGround == true)
		{
			
			//Allow the player to jump off of their rope
			ropeShotSpot = GameObject.Find("RopeShotSpot");
			ropeShotSpot.GetComponent<scrShootRope>().isSwinging = false;
			
			rigidbody.AddForce(0, jumpForce, 0);	//push player up
			isTouchedGround = false;	//They are no longer touching the ground
		}
			// Player horizontal camera movement
		if(Input.GetButton("Fire2"))
		{
			float rotY = rotSpd * Input.GetAxis("MouseLookX");
			transform.Rotate(Vector3.up, rotY);	//rotate player around y
		}
		
	}
	
		
	
	
		//Check for player collision with the ground or goal
	void OnCollisionEnter(Collision hit)
	{
			//if player has hit the ground, they can jump again.
		if(hit.gameObject.name == "floor")
		{
			isTouchedGround = true;
		}
		
			//if the player has reached the goal
	//	if(hit.gameObject.name == "goal")
	//	{
	//		isVictory = true;		
	//	}
	}
	
	
	
	/*
		//Graphical User Interface (For Victory screen)
	void OnGUI()
	{
		if(isVictory)
		{
			print ("You won!!!!!");
			
				//image box for when you win
			GUI.DrawTexture(new Rect(Screen.width/2.0f - textureWinWidth/2.0f, Screen.height/2.0f - textureWinHeight/2.0f, textureWinWidth, textureWinHeight), textureWin);	
				//Text box for when you win
			GUI.Box(new Rect(Screen.width/2.0f - textureWinWidth/2.0f, Screen.height/2.0f - textureWinHeight/2.0f, textureWinWidth, textureWinHeight), "You Won!!!");	
		}
	}*/
}

/*
 * 
 * void OnCollisionStay(Collision hit)
 * {
 * 	foreach( ContactPoint contact in hit.contacts)
 * {
 * 	if(Vector3.Angle(contact.normal, Vector3.up) < 35)
 * {
 * isGrounded = true;
 * print("grounded");
 * return;
 * }
 * }
 * }
 * 
 * 
 * void OnCollisionExit()
 * {
 * isGrounded = false;
 * print("Not Grounded");
 * }
 * */
