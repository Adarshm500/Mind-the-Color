using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
