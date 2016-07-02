// Uses AutoWalk script by JuppOtto 
// Source : Github
// https://github.com/JuppOtto/Google-Cardboard
// Originally written for Google Cardboard SDK
// Modified by VRNepal for Google VR SDK according to program requirement

using UnityEngine;
using System.Collections;

public class AutoWalk : MonoBehaviour 
{
	private const int RIGHT_ANGLE = 90; 

	// This variable determinates if the player will move or not 
	private bool isWalking = false;
	GvrHead head = null;

	//This is the variable for the player speed
	[Tooltip("With this speed the player will move.")]
	public float speed;


	[Tooltip("Activate this checkbox if the player shall move when he looks below the threshold.")]
	public bool walkWhenLookDown;

	[Tooltip("This has to be an angle from 0° to 90°")]
	public double thresholdAngle;

	[Tooltip("This is the fixed y-coordinate.")]
	private Vector3 moveDirection = new  Vector3(0,0,0);

	GameObject camera;
	CharacterController cameraController;

	void Start () 
	{
		head = Camera.main.GetComponent<StereoController>().Head;
	}

	void Update () 
	{	
		camera = GameObject.Find ("GvrMain");
		cameraController = camera.GetComponent<CharacterController> ();

		// Walk when player looks below the threshold angle 
		if (walkWhenLookDown && !isWalking &&  
			head.transform.eulerAngles.x >= thresholdAngle && 
			head.transform.eulerAngles.x <= RIGHT_ANGLE) 
		{
			
			isWalking = true;
		} 
		else if (walkWhenLookDown && isWalking && 
			(head.transform.eulerAngles.x <= thresholdAngle ||
				head.transform.eulerAngles.x >= RIGHT_ANGLE)) 
		{
			isWalking = false;
		}



		if (isWalking) 
		{
			Vector3 moveDirection = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;

			cameraController.SimpleMove(moveDirection);
		}



	}
}