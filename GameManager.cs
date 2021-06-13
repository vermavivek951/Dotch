using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void gamePause()
    {
        UIManager _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uiManager != null)
        {
            _uiManager.pausethegame();
        }
        //ManageScoreduringPlayPause(1);
    }

    public void gameResume()
    {
        UIManager _uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uimanager != null)
        {
             _uimanager.resumethegame();
        }
       // ManageScoreduringPlayPause(2);
    }

    public void home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(3);
    }

    public void Settings()
    {
        SceneManager.LoadScene(4);
    }

    /* private void ManageScoreduringPlayPause(int state)
     {
         ScoreManager _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
         if (_scoreManager != null && state == 1 )
         {
             _scoreManager.GameisPause();
         }
         if (_scoreManager != null && state == 2)
         {
             _scoreManager.GameisResumed();
         } 
      }*/

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
