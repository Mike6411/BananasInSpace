using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaRotate : MonoBehaviour
{
    /*Bananas Rotate*/

    [SerializeField]
    LevelControler LC;
    [SerializeField]
    float rotation = 70f;
    [SerializeField]
    AudioSource coinFX;

    private void Start()
    {
        LC = GameObject.Find("LevelControler").GetComponent<LevelControler>();
    }

    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
        /*float updown = Mathf.PingPong(Time.time * speedUpDown, length);
        transform.position = new Vector3( transform.position.x , transform.position.y + updown, transform.position.z);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LC.bananas++;
            coinFX.Play();
            this.gameObject.SetActive(false);
        }
    }
}
