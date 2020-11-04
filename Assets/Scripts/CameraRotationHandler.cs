using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraRotationHandler : MonoBehaviour
{
    public GameObject cameraRotationOrigin;
    public GameObject player;

    public float sensitivity;
    public bool active = true;

    private void Update()
    {
        cameraRotationOrigin.transform.position = player.transform.position;
    }

    private void LateUpdate()
    {
        if (active)
        {
            float horizontal = Input.GetAxis("Mouse X") * sensitivity;
            float vertical = Input.GetAxis("Mouse Y") * sensitivity;

            cameraRotationOrigin.transform.Rotate(Vector3.up, horizontal, Space.World);
            cameraRotationOrigin.transform.Rotate(Vector3.left, vertical, Space.Self);

            transform.LookAt(player.transform);
        }
    }
}
