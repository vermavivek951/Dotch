using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpriteOnBall : MonoBehaviour
{
    public GameObject _ballPrefab;
    public Sprite[] sprites;

    private void Start()
    {
        _ballPrefab.transform.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    public void ChangeSprite(int index)
    {
        _ballPrefab.transform.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    private void OnDestroy()
    {
        _ballPrefab.transform.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }
}
