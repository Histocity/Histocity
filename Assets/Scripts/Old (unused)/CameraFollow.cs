using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public  Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(01f, 10f)]
    public float SmoothFactor = 0.05f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // LateUpdate after all the other Update methods
    void LateUpdate()
    {
        if (RotateAroundPlayer)
        {
            //calculates Angleaxis of Camera with Mouse 
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        //calculating new position of the camera, interpolate with Slerp method with SmoothFactor 
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
        
    }
}

//https://www.youtube.com/watch?v=urNrY7FgMao&feature=youtu.be 
//https://www.youtube.com/watch?v=xcn7hz7J7sI