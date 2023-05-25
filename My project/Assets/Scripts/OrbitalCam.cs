using UnityEngine;
using UnityEngine.InputSystem;

public class OrbitalCam : MonoBehaviour
{
    [SerializeField]
    Transform Player;

    [SerializeField]
    private float camSpeed = 3;

    [SerializeField]
    private float orbitDamping = 10;

    [SerializeField]
    private float minCamClamp = 30f;

    [SerializeField]
    private float maxCamClamp = 80f;

    private Vector3 localRot;

    void Update()
    {
        //Anclamos la camara al jugador
        transform.position = Player.position;

        //Movemos la camara con los axis del raton
        localRot.x += Input.GetAxis("Mouse X") * camSpeed;
        localRot.y += Input.GetAxis("Mouse Y") * camSpeed;

        localRot.y = Mathf.Clamp(localRot.y, minCamClamp, maxCamClamp);

        Quaternion QT = Quaternion.Euler(localRot.y, localRot.x, 0f);

        //Lerp para que quede mas fluido
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);

    }
}
