using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketstallInteraction : MonoBehaviour
{
    private bool isInteracting = false;

    public GameObject questionDialogue;
    public Button continueButton;

    private void Start()
    {
        continueButton.onClick.AddListener(CloseQuestionDialogue);
    }

    public void Interact()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            GameManager.instance.PauseWithoutMenu();
            questionDialogue.SetActive(true);
        }
    }

    public void CloseQuestionDialogue() {
        questionDialogue.SetActive(false);
        GameManager.instance.ResumeGame();
        isInteracting = false;
        // Ready a new question
        questionDialogue.GetComponent<questionController>().PresentQuestion();
    }
}
