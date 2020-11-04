using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float rotationSpeed = 110.0f;
    public Camera cam;
    Animator anim;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        anim = transform.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkHandler();
    }
    void WalkHandler()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
         
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * walkSpeed, rb.velocity.y, moveVertical * walkSpeed);

        // Get flattend camera angle (to move player relative to camera instead of to himself)
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0f;
        Quaternion flattendCamRotation = Quaternion.LookRotation(camForward);

        // Change movement relative to flattend camera angle.
        movement = flattendCamRotation * movement;

        rb.velocity = movement;

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
            // Rotate towards where you're walking
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
}