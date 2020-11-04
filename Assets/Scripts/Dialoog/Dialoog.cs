using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=f-oSXg6_AMQ


public class Dialoog : MonoBehaviour
{
    public Text textDisplay;

    [TextArea(3,10)]
    public string[] sentences;

    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    

    void Start()
    {
        StartCoroutine(DisplayText());
        Button continueButton = GameObject.Find("Continue Button").GetComponent<Button>();
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(NextSentence);
    }

    //Display text by character letter
    IEnumerator DisplayText()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false); // cann't spawn click to bug game, hide continuebutton

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(DisplayText());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false); // cann't spawn click to bug game, hide continuebutton
        }
    }

}
