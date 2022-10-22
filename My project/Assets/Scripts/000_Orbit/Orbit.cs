using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float targetDistance;

    [SerializeField]
    private float cameraLerp;

    [SerializeField]
    private float rotationX;

    [SerializeField]
    private float rotationY;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        /*Get Values*/
        rotationX += Input.GetAxis("Mouse Y");
        rotationY += Input.GetAxis("Mouse X");

            /*Limit Rotation*/
            rotationX = Mathf.Clamp(rotationX, -50f, 50f);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        /*Lerp and Apply*/
        transform.position = Vector3.Lerp(transform.position, target.transform.position - transform.forward * targetDistance, cameraLerp * Time.deltaTime);
    }



}

