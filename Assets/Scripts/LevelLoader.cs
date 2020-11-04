using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel (int sceneIndex)
    {   
        //calls coroutine
        StartCoroutine(LoadAsynchronously(sceneIndex)); 
    }

    //loads scene asynchronsously using sceneIndex stored into var 'operation'
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)//(!operation.isDone == false)
        {
            //value from 1 to 0.9 goes to 0 to 1
            float progress = Mathf.Clamp01(operation.progress/.9f);

            //each time it runs through get Debug.Log
            slider.value = progress;

            yield return null; //wait until next frame before continueing
        }
    }
   
}
