using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDropMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setspeed();
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <-15f)
        {
            if (this.tag == "ball")
                transform.position = new Vector3(Random.Range(-11.85f, 11.85f), 1, -0.1f);
            else
                Destroy(this.gameObject);
        }
    }

    public void setspeed()
    {
        _speed = Random.Range(7, 10);
    }
}