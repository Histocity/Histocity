using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenuAttribute]
public class questions : ScriptableObject
{
    [SerializeField]
    private string question = null;

    [SerializeField]
    private string[] answers = null;

    public int correctAnswer;

    public string Question { get { return question; } }
    public string[] Answers { get { return answers; } }
    public int CorrectAnswer { get { return correctAnswer; } }

    public bool Asked { get; internal set; }
}
