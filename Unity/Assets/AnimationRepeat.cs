using UnityEngine;
using System.Collections;

public class AnimationRepeat : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
		 gameObject.animation.wrapMode = WrapMode.Loop;


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
