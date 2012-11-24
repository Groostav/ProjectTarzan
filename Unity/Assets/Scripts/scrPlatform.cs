using UnityEngine;
using System.Collections;

public class scrPlatform : MonoBehaviour {

    public GameObject NextPlatform;
    public float Multiplier;

    private const float HalfRoot2 = 1 / 1.41421356237F;
    private const float _relativeAngle = 20F;

    private bool contact;

	// Use this for initialization
	void Start ()
	{
	    Multiplier = (Multiplier == default(float) ? 1.0F : Multiplier);
	    contact = false;
	}
	
	// Update is called once per frame
	public void Update () 
    {
        if (Input.GetButtonDown("Jump") && contact)
        {
            var player = GameObject.Find("player");
            player.transform.position = player.transform.position + new Vector3(0, 0.1F, 0);
            //TODO: use the capsules bottom position.

            var displacement = NextPlatform.transform.position - player.transform.position;//(player.transform.position + new Vector3(0, -0.5f, 0));
            //        print("player to platform is: " + displacement);

            var platformAngle = 90F - Vector3.Angle(displacement, Vector3.up);
            //        print("platform angle is : " + platformAngle);

            var desiredAngle = (_relativeAngle / 90F) * (90F - platformAngle) + platformAngle;
            //        print("desired angle is " + desiredAngle);

            var numerator = (HalfRoot2 * Mathf.Sqrt(Physics.gravity.magnitude) * displacement.x * (1 / Mathf.Cos(desiredAngle.InRadians())));
            //        print("Numerator is " + numerator);

            var denominator = Mathf.Sqrt(Mathf.Abs(displacement.y - displacement.x * Mathf.Tan(desiredAngle.InRadians())));
            //        print("Denominator is " + denominator);
            var velocityMagnitude = numerator / denominator;

            //        print(string.Format("calling Vector3.RotateTowards({0}, {1}, {2}, 0.0F)", displacement.normalized, Vector3.up, desiredAngle - platformAngle));
            var direction = Vector3.RotateTowards(displacement.normalized, Vector3.up, (desiredAngle - platformAngle).InRadians(), 0.0F);
            direction = direction.normalized;

            //        print(string.Format("Position: {0}, Velocity Magnitude: {1}, Velocity Direction: {2}", displacement,
            //                            velocityMagnitude, direction));

            player.rigidbody.velocity = (velocityMagnitude * direction) * Multiplier;
            //TODO remove multiplier        var player = GameObject.Find("player");

            contact = false;
        }
	}

    public void OnCollisionEnter(Collision collision)
    {
        print("Contact!");
        contact = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        print("open!");
        contact = false;
    }
}

public static class FloatExtensions
{
    public static float InRadians(this float degrees)
    {
        return degrees*Mathf.PI/180F;
    }

    public static float InDegrees(this float radians)
    {
        return radians*180F/Mathf.PI;
    }
}

public static class Vector3Extensions
{
    public static Vector3 AsInverted(this Vector3 vectorToInvert)
    {
        return new Vector3(-1 * vectorToInvert.x, -1 * vectorToInvert.y, -1 * vectorToInvert.z);
    }
}
