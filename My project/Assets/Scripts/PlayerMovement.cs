using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float moveSpeed = 10;

    [SerializeField]
    float jumpHeight = 5;

    [SerializeField]
    float jumpCount = 1;

    [SerializeField]
    Transform camTransform;

    public bool respawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        if(Input.GetButtonDown("Jump")) rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);


        if (rb.velocity.x > 0f || rb.velocity.z > 0f) { 
        transform.forward = new Vector3(rb.velocity.x, 0 , rb.velocity.z);
        }
}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            respawn = true;
        }
    }


}
