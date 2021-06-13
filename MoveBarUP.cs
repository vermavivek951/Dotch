using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarUP : MonoBehaviour
{
    [SerializeField]
    private GameObject _bar;
    [SerializeField]
    private int _collectableCount;
    
    private float _raise = 1.0f;
    private bool _toCount = true;
   
    private UIManager _uiManager;
    private barmovement _barMovement;
    private GameManager _gameManager;
    //private ScoreManager _scoreManager;

    void Start()
    {
       _collectableCount = 0;

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _barMovement = GameObject.Find("bar").GetComponent<barmovement>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //_scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        nullcheck();
    }

    private void nullcheck()
    {
        if (_uiManager == null)
        {
            Debug.LogError("UIManager is Null");
        }
        if (_barMovement == null)
        {
            Debug.LogError("bar is NULL");
        }
        if (_gameManager == null)
        {
            Debug.LogError("GameManager is Null");
        }
      /*  if (_scoreManager == null)
        {
            Debug.LogError("ScoreManager is Null");
        }*/
    }

    public void _ModeNumberis1()
    {
        _toCount = true;
    }

    public void _ModeNumberis2()
    {
        _toCount = false;
    }

    public void enemytozero()
    {
        _collectableCount = 0;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable")
        {
            moveBarUp();
        }
    }
    
    public void moveBarUp()
    {
        updateBallMissedUI();

        if (_collectableCount >= 5)
        {
            _bar.transform.position = new Vector3(_bar.transform.position.x, _bar.transform.position.y + _raise, _bar.transform.position.z);
            if (_bar.transform.position.y >= -9)
            {
                _gameManager.OnGameOver();
                Destroy(_bar.gameObject);

                _toCount = false;
            }
            _collectableCount = 0;
            _uiManager.addballsMissed(_collectableCount);
        }
    }

    public void updateBallMissedUI()
    {
        _collectableCount++;
        _uiManager.addballsMissed(_collectableCount);
    }
}
