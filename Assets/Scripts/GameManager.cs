using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct Tags
{
    public const string Interactable = "Interactable";
    public const string Player = "Player";
}

public class GameManager : MonoBehaviour
{
    private hudManager hudManager;
    private CameraRotationHandler cameraScript;
    private bool isPausedWithMenu;
    private bool isPauseWithoutMenu;

    public static GameManager instance = null;
   
    // Called when the object is initialized
    void Awake()
    {  
        // if it doesn't exist
        if (instance == null)
        {
            // Set the instance to the current object (this)
            instance = this;
        }

        // There can only be a single instance of the game manager
        else if (instance != this)
        {
            // Destroy the current object, so there is just one manager
            Destroy(gameObject);
        }

        // Don't destroy this object when loading scenes
        DontDestroyOnLoad(gameObject);
    }

    public void GoToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        if(!isPauseWithoutMenu)
        {
            PauseWithoutMenu();
            // Find scripts (must happen here so the script are found again after switching scenes)
            hudManager = GameObject.Find("HUD manager").GetComponent<hudManager>();

            hudManager.pausescreen.SetActive(true);
            isPausedWithMenu = true;
        }

    }

    public void PauseWithoutMenu()
    {
        // Find script (must happen here so the script are found again after switching scenes)
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraRotationHandler>();

        Time.timeScale = 0f;
        cameraScript.active = false;

        isPauseWithoutMenu = true;
    }

    public void ResumeGame()
    {
        // Find scripts (must happen here so the script are found again after switching scenes)
        hudManager = GameObject.Find("HUD manager").GetComponent<hudManager>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraRotationHandler>();

        Time.timeScale = 1f;
        hudManager.pausescreen.SetActive(false);
        cameraScript.active = true;
        isPausedWithMenu = false;
        isPauseWithoutMenu = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPausedWithMenu == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

}
