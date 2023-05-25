using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    private float jumpMax = 3;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private float sprintMultiplier = 1.5f;

    [SerializeField]
    private float jumpHeight = 5;

    [SerializeField]
    public float jumpCount;

    [SerializeField]
    Transform camTransform;

    public bool respawn;

    private string enemyTag = "Enemy";
    private string floorTag = "Ground";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = jumpMax;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //Gestion de velociad mientras se hace sprint
        Sprint();

        //Inputs
        float horInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verInput = Input.GetAxisRaw("Vertical") * moveSpeed;

        //Direcion de la camara
        Vector3 camForward = camTransform.forward;
        Vector3 camRight = camTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        //Creando direccion de la camara relativa
        Vector3 forwardRelative = verInput * camForward;
        Vector3 rightRelative = horInput * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        //Àplicar el movimiento al rb
        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        //Saltar al darle al Jump y -- por cada vez que se salta
        if (Input.GetButtonDown("Jump") && jumpCount != 0) { rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z); jumpCount--; };

        //Que se quede mirando hacia donde estaba mirando
        if (rb.velocity.x != 0f || rb.velocity.z != 0f)
        {
            transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }

    private void Sprint ()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed * sprintMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed / sprintMultiplier;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Gestion de colisiones

        if (other.tag == enemyTag)
        {
            respawn = true;
        }

        if (other.tag == floorTag)
        {
            jumpCount = jumpMax;
        }

    }

}
