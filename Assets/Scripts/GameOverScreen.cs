using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public static bool GameOver = false;
    void Update()
    {
        if (GameOver )
        {
            End();   
        }
        else
        {
            Time.timeScale = 1f;
        }
    

    }

    void End()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameOver = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartButton()
    {

        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {

        SceneManager.LoadScene("Main Menu");
    }



}
