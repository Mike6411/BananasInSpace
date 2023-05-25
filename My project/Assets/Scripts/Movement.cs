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

	[SerializeField]
	AudioSource jumpFX;

	private Vector3 moveDirection = Vector3.zero;
    private float gravity = 9.81f;
    private float accelPerSec;
    private float currentSpeed;
    private bool isMoving;
	private string enemyTag = "Enemy";
	public bool respawn;


	void Start()
	{
		accelPerSec = maxSpeed / zeroToMax;
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		jumps = 3;
	}

	void Update()
	{
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
			//no se porque sale con delay 
			jumpFX.Play();
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
        {
			respawn = true;
        }
    }

	//Acceleration
	private void setSpeed()
    {
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

