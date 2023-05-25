using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimsScript : MonoBehaviour
{
    private Animator anim;


    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Anim Checks*/
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
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
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("AnimationPar", 3);
        }
    }
}
