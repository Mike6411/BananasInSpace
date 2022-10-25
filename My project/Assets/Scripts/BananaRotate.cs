using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaRotate : MonoBehaviour
{
    /*Bananas Rotate*/

    [SerializeField]
    float speedUpDown = 10f;
    [SerializeField]
    float rotation = 70f;
    [SerializeField]
    float length = 0.2f;

    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
        float y = Mathf.PingPong(Time.time * speedUpDown, length);
        transform.position = new Vector3( transform.position.x , y + 1, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
