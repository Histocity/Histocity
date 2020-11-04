using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used to create an interactable object. Use as follows:
// - Attach this script to interactable object
// - Add a collider with the interaction range
// - Create new script with an function: Interact(), this function will be the interaction
// - Make sure the interaction ends in that script (if a box pops up, make sure that that script removes the box again)
// - Attach the new script to the same object, this script will call the interact function when E is pressed.
[RequireComponent(typeof(Collider))]
public class _Interactable : MonoBehaviour
{
    private string interactText = "Press E to interact with ";
    private bool isPlayerInRange = false;

    // Editor variables
    public string interactableName;
    public Text interactTextObject;

    private void OnTriggerEnter(Collider collider)
    {
        interactTextObject.text = interactText + interactableName;
        if (collider.gameObject.name == Tags.Player)
        {
            interactTextObject.gameObject.SetActive(true);
            isPlayerInRange = true;
        } 
    }   
    
    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.name == Tags.Player)
        {
            interactTextObject.gameObject.SetActive(false);
            isPlayerInRange = false;
        } 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            SendMessage("Interact");
        }
    }
}
