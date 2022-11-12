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
	float jumpHeight = 19.81f;

	[SerializeField]
	float sprintMultiplier;

	[SerializeField]
	int jumps;

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
		jumps = 3;
	}

	void Update()
	{
		//Set Accel
		setSpeed();

		grounded = controller.isGrounded;

		//Jump Refill
        if (grounded){jumps = 3;}

        /*Movement Checks*/
        if (Input.GetAxis("Vertical") != 0)
        {
			isMoving = true;
        }
		else
        {
			isMoving = false;
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
			sprintMultiplier = Mathf.Lerp( 0.1f, 2.0f, 1f);
		}else
        {
			sprintMultiplier = 1;
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (jumps > 0)
			{
				grounded = false;
				moveDirection.y = 0;
				moveDirection.y = jumpHeight;
				anim.SetInteger("AnimationPar", 3);
				jumps--;
			}
		}

		/*apply speed forward*/
		if (grounded)
		{
			moveDirection = transform.forward * Input.GetAxis("Vertical") * currentSpeed * sprintMultiplier;
		}

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

	
		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);

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

