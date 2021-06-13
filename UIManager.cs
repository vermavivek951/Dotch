using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ballsMissedText;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _pausedPanel;
    [SerializeField]
    private Text _highScore;
    [SerializeField]
    private float _curHighScore;
    [SerializeField]
    private float score = 0;


    private void Start()
    {
        _curHighScore = PlayerPrefs.GetFloat("HighScore", 0);
        _highScore.text = "High Score: " + _curHighScore.ToString("F0");
        _scoreText.text = "Score: " + score.ToString("F0");
    }


    public void addballsMissed(int count)
    {
        _ballsMissedText.text = "Missed: " + count.ToString();
    }
    
    public void ballsMissedtoZero()
    {
        _ballsMissedText.text = "Missed: 0";
    }

    public void scoreUpdate(float point)
    {
        score += point;
        _scoreText.text = "Score: " + score.ToString("F0");
       
        if (score > _curHighScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            _highScore.text = "High Score: " + score.ToString("F0");
        }
    }

    public void pausethegame()
    {
        _pausedPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void resumethegame()
    {
        _pausedPanel.SetActive(false);
        Time.timeScale = 1;
    }

   
}
