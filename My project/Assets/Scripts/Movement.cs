using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private Animator anim;
	private CharacterController controller;

    [SerializeField]
	float maxSpeed = 5.0f;

	[SerializeField]
	float zeroToMax = 0.5f;

    [SerializeField]
	float turnSpeed = 400.0f;

	[SerializeField]
	bool grounded;

	[SerializeField]
	float jumpHeight = 10f;

	[SerializeField]
	float sprintMultiplier;

	/*[SerializeField]
	float gravityMultiplier = 1f;*/

	private Vector3 moveDirection = Vector3.zero;
	float gravity = 9.81f;
	float accelPerSec;
	float currentSpeed;
	bool isMoving;

	void Start()
	{
		accelPerSec = maxSpeed / zeroToMax;
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		//Set Accel
		setSpeed();

        /*Movement Checks*/
        if (Input.GetAxis("Vertical") != 0)
        {
			isMoving = true;
        }
		else
        {
			isMoving = false;
        }

		/*Grounded Checks*/
		if (controller.isGrounded)
		{
			grounded = true;
			moveDirection = transform.forward * Input.GetAxis("Vertical") * currentSpeed;
        }
		if (controller.isGrounded == false)
		{
			grounded = false;
		}

		/*Crouch checks*/
		if (Input.GetKey(KeyCode.LeftControl))
        {
			Debug.Log("crouch");
        }

		/*Anim Checks*/
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetInteger("AnimationPar", 1);
		}
		else
		{
			anim.SetInteger("AnimationPar", 0);
		}
		if (Input.GetKey(KeyCode.LeftShift))
		{
			anim.SetInteger("AnimationPar", 2);
			sprintMultiplier = 2;
		}else
        {
			sprintMultiplier = 1;
        }

		if (Input.GetKey(KeyCode.Space))
		{
            anim.SetInteger("AnimationPar", 3);
            if (grounded)
            {
				moveDirection.y += Mathf.Sqrt(jumpHeight * -1.0f * gravity);
            }

		}


		/*apply speed forward*/
		if (grounded)
		{
			moveDirection = transform.forward * Input.GetAxis("Vertical") * currentSpeed * sprintMultiplier;
		}

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}

	void setSpeed()
    {
		//Acceleration
		if (isMoving)
		{
			if (currentSpeed <= maxSpeed)
			{
				currentSpeed += accelPerSec * Time.deltaTime;
			}
        }
        else { currentSpeed = 0; }
    }
}

