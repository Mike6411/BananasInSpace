using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private Animator anim;
	private CharacterController controller;

    [SerializeField]
	float speed = 600.0f;

    [SerializeField]
	float turnSpeed = 400.0f;

	[SerializeField]
	bool grounded;

	[SerializeField]
	float jumpHeight;

	[SerializeField]
	float sprintMultiplier;

	/*[SerializeField]
	float gravityMultiplier = 1f;*/

	private Vector3 moveDirection = Vector3.zero;
	float gravity = 9.81f;

	void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		/*Grounded Checks*/
		if (controller.isGrounded)
		{
			grounded = true;
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }
		if (controller.isGrounded == false)
		{
			grounded = false;
		}

		/*Anim Checks*/
		if (Input.GetKey("w"))
		{
			anim.SetInteger("AnimationPar", 1);
		}
		else
		{
			anim.SetInteger("AnimationPar", 0);
			sprintMultiplier = 1;
		}
		if (Input.GetKey("left shift"))
		{
			anim.SetInteger("AnimationPar", 2);
			sprintMultiplier = 2;
		}
		if (Input.GetKey("space"))
		{
			Debug.Log("Saltito");
            //anim.SetInteger("AnimationPar", 3);
            if (grounded)
            {
				moveDirection.y += Mathf.Sqrt(jumpHeight * -1.0f * gravity);
            }

		}


		/*apply speed forward*/
		if (grounded)
		{
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed * sprintMultiplier;
		}

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y += gravity * Time.deltaTime;
	}
}

