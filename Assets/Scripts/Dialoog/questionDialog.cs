using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=f-oSXg6_AMQ

public class questionDialog : MonoBehaviour
{
    public Text textDisplay;

    public Button[] answerButtons;
    
    public questionController questionController;
    public Button continueButton;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;



    void Start()
    {
        // makes health in beginning max health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void SetupUIForQuestion(questions question)
    {
        textDisplay.text = question.Question;

        for (int i = 0; i < question.Answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
        }
        for (int i = question.Answers.Length; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
    }

    public void HandleSubmittedAnswer(bool isCorrect)
    {
        ToggleAnswerButtons(false);
        if (isCorrect)
        {
            textDisplay.text = "Het antwoord is goed!";
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            TakeDamage(20); //take 20 health damage
            textDisplay.text = questionController.currentQuestion.Question +  "\n\nHet antwoord is Fout! Probeer het nog eens";
            continueButton.gameObject.SetActive(false);
            ToggleAnswerButtons(true);
        }
    }

    private void ToggleAnswerButtons(bool value)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(value);
        }
    }

    //currentHealth minus damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


}
