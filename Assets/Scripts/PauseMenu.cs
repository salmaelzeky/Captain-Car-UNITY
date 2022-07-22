using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public static bool GameIsPaused = false;
    public GameObject newMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = !GameIsPaused;
            PauseGame();
        }
        
    }

    void PauseGame()
    {
        newMenuUI.SetActive(true);
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("Time: " + Time.timeScale);
            Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {
            newMenuUI.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("Time: " + Time.timeScale);
        }

    }


    public void ResumeGame()
    {
        newMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

   
    public void RestartGame()   
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
