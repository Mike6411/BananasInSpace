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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;

        localRot.x += Input.GetAxis("Mouse X") * camSpeed;
        localRot.y += Input.GetAxis("Mouse Y") * camSpeed;

        localRot.y = Mathf.Clamp(localRot.y, minCamClamp, maxCamClamp);

        Quaternion QT = Quaternion.Euler(localRot.y, localRot.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);

    }
}
