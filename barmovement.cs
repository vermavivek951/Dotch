using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barmovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    private int _modeNumber = 1; // 1:catch mode , 2:dodge mode
    float middle = Screen.width / 2;
    float height = Screen.height / 2;

    private UIManager _uiManager;
    private GameManager _gameManager;
   
    private MoveBarUP _moveUp;
    private SpawnManager _spawnManager;
    private SwitchSpriteOnBall _spriteManager;


    
    void Start()
    {
        transform.position = new Vector3(0f, -14f, -0.25f);
       
        _moveUp = GameObject.Find("Floor").GetComponent<MoveBarUP>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        nullCheck();

    }

    private void nullCheck()
    {
        if (_moveUp == null)
        {
            Debug.LogError("MoveUp is NULL.");
        }
        if (_uiManager == null)
        {
            Debug.LogError("UIManager is NULL.");
        }
        if (_gameManager == null)
        {
            Debug.LogError("GameManager is Null");
        }
        if (_spawnManager == null)
        {
            Debug.LogError("SpawnManager is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TouchMove();
        CalculateMovement();
    }

    public void TouchMove()
    {

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.position.x > middle && touch.position.y < height && touch.phase == TouchPhase.Stationary)
            {
                MoveRight();
            }
            else if(touch.position.x < middle && touch.position.y < height && touch.phase == TouchPhase.Stationary)
            {
                MoveLeft();
            }

        }
    }

    public void MoveLeft()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -14f, 14f), transform.position.y, transform.position.z);
       
        if (transform.position.x < -14f)
        {
            transform.position = new Vector3(14f, transform.position.y, transform.position.z);
        }
    }
    
    public void MoveRight()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -14f, 14f), transform.position.y, transform.position.z);
        
        if (transform.position.x > 14f)
        {
            transform.position = new Vector3(-14f, transform.position.y, transform.position.z);
        }
    }

    public void CalculateMovement()
    {
        if ((Input.GetKey(KeyCode.LeftArrow)))
        {
            MoveLeft();
        }

        if ((Input.GetKey(KeyCode.RightArrow)))
        {
            MoveRight();
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "collectable")
        {
            _uiManager.scoreUpdate(50);
            Destroy(other.gameObject);
        }
        else if(other.tag == "evil")
        {
            _moveUp.moveBarUp();
            _uiManager.scoreUpdate(-30);
            Destroy(other.gameObject);
        }
    }
}