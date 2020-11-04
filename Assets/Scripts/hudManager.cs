using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hudManager : MonoBehaviour
{
    private Text coinAmountText;

    public GameObject pausescreen;

    // pausescreen buttons
    public Button pauseContinueButton;
    public Button pauseQuitButton;

    private void Awake()
    {
        // Disable pausescreen
        pausescreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseQuitButton.onClick.AddListener(QuitButtonPressed);
        pauseContinueButton.onClick.AddListener(GameManager.instance.ResumeGame);


        coinAmountText = GameObject.Find("coin amount text").GetComponent<Text>();
    }

    private void QuitButtonPressed()
    {
        GameManager.instance.ResumeGame();
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    public void updateCoinAmount(int newAmount)
    {
        coinAmountText.text = newAmount + " x";
    }
}
