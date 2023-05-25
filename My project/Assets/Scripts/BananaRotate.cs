using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaRotate : MonoBehaviour
{
    /*https://www.youtube.com/watch?v=2BrIPhuUxBQ*/ //mi inspiracion

    [SerializeField]
    LevelControler LC;
    [SerializeField]
    private float rotation = 70f;
    [SerializeField]
    AudioSource coinFX;
    [SerializeField]
    private float bananasToWin = 40;

    private void Start()
    {
        LC = GameObject.Find("LevelControler").GetComponent<LevelControler>();
    }

    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LC.bananas++;
            coinFX.Play();
            this.gameObject.SetActive(false);
        }

        if (LC.bananas == bananasToWin)
        {
            LC.win = true;
        }
    }
}
