using UnityEngine;
using System.Collections;

public class scrPlayer : MonoBehaviour
{
    private float strafeSpd = 0.6f; //horizontal strafe speed
    private float fbSpd = 0.6f; //forward backwards speed	
    private float rotSpd = 2.0f; //rotation speed per frame
    private float jumpForce = 2000.0f; // jump force

    public bool isTouchedGround = false; //Has the player touched the ground since his last jump?

    private GameObject ropeShotSpot; // A handel to the rope's shot spot


    // Use this for initialization
    private void Start()
    {
        //nothing
        //Physics.gravity = Vector3.zero;
    }




    // Update is called once per frame
    private void Update()
    {
        //nothing
    }




    //guarnteed to run each frame
    private void FixedUpdate()
    {

        //		rigidbody.AddForce(0.0f, gravityForce, 0.0f);//apply gravity down

        //player directional movement
        float s = strafeSpd*Input.GetAxis("Strafe");
        float fb = fbSpd*Input.GetAxis("ForwardBack");
        transform.Translate(s, 0, fb); //movement x, and z


        //Player jump ability (has to have touched the ground since last jump)
        if (Input.GetButtonDown("Jump") && isTouchedGround )
        {
            //Allow the player to jump off of their rope
            this.gameObject.GetComponentInChildren<scrShootRope>().isSwinging = false;

            rigidbody.AddForce(0, jumpForce, 0); //push player up
            isTouchedGround = false; //They are no longer touching the ground
        }
        // Player horizontal camera movement
        if (Input.GetButton("Fire2"))
        {
            float rotY = rotSpd*Input.GetAxis("MouseLookX");
            transform.Rotate(Vector3.up, rotY); //rotate player around y
        }

    }




    //Check for player collision with the ground or goal
    private void OnCollisionEnter(Collision hit)
    {
        //if player has hit the ground, they can jump again.
        isTouchedGround = hit.gameObject.name == "l_canyon";

        return;
    }
}