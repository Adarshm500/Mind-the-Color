using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");

        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
