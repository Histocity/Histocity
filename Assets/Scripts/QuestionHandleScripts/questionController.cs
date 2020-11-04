using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionController : MonoBehaviour
{
    private questionCollection questionCollection;
    public questions currentQuestion;
    private questionDialog questionDialog;
    
    private void Awake() {
        questionCollection = FindObjectOfType<questionCollection>();
        questionDialog = FindObjectOfType< questionDialog>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PresentQuestion();
    }

    public void PresentQuestion()
    {
        currentQuestion = questionCollection.GetUnaskedQuestions();
        questionDialog.SetupUIForQuestion(currentQuestion);
        questionDialog.continueButton.gameObject.SetActive(false);
    }

    public void SubmitAnswer(int answerNumber)
    {
        bool isCorrect = answerNumber == currentQuestion.CorrectAnswer;
        questionDialog.HandleSubmittedAnswer(isCorrect);
    }
}
