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

    public bool respawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verInput = Input.GetAxisRaw("Vertical") * moveSpeed;

        rb.velocity = new Vector3(horInput, rb.velocity.y, verInput);

        if(Input.GetButtonDown("Jump")) rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);

        transform.forward = new Vector3(rb.velocity.x, 0 , rb.velocity.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            respawn = true;
        }
    }


}
