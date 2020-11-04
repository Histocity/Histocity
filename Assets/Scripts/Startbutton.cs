using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button startButton = this.gameObject.GetComponent<Button>();
        startButton.onClick.AddListener(StartButtonPressed);
    }

    private void StartButtonPressed()
    {
        GameManager.instance.GoToNextLevel();
    }
}
