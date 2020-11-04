using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(_Interactable))]
public class SignInteraction : MonoBehaviour
{
    private bool textBoxCloseable = false;
    private bool isInteracting = false;

    // Editor variables
    public string title = "Sign";
    public string info = "Dit is de tekst van de info sign";
    public GameObject textBox;

    private void Start()
    {
        Text titleText = textBox.transform.Find("Title").GetComponent<Text>();
        Text infoText = textBox.transform.Find("Info").GetComponent<Text>();

        titleText.text = title;
        infoText.text = info;
    }

    public void Interact()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            GameManager.instance.PauseWithoutMenu();
            textBox.SetActive(true);
            StartCoroutine(SetTextBoxClosableAfterSeconds(0.1f));
        }
    }

    private void Update()
    {
        if(textBoxCloseable &&(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E) ) )
        {
            textBox.SetActive(false);
            textBoxCloseable = false;
            GameManager.instance.ResumeGame();
            isInteracting = false;
        }
    }

    IEnumerator SetTextBoxClosableAfterSeconds(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        textBoxCloseable = true;
    }
}
