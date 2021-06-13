using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _collectableandEvilPrefab;
    [SerializeField]
    private GameObject _ballcontainer;
    [SerializeField]
    private int _numberofObjectToSpawn = 4;
   
    
   
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(ballSpawn());
       // StartCoroutine(specialballSpawn());
    }

    

    IEnumerator ballSpawn()
    {
        while (true)
        {
            float randomSeconds = Random.Range(1f, 1.2f);
            yield return new WaitForSeconds(randomSeconds);

/*          float[] area = new float[4];
            area[0] = Random.Range(-11.85f, -5.85f);
            area[1] = Random.Range(-5.85f, 0f);
            area[2] = Random.Range(0f, 5.85f);
            area[3] = Random.Range(5.85f, 11.85f);

            int randomareaIndex = Random.Range(0,4); */

            Vector3 posToSpawn = new Vector3(Random.Range(-8f,11f), 1, -0.1f);
            int index = Random.Range(0, _numberofObjectToSpawn);

            GameObject newBall = Instantiate(_collectableandEvilPrefab[index], posToSpawn, Quaternion.identity);
            newBall.transform.parent = _ballcontainer.transform;
        }
    }

/*  IEnumerator specialballSpawn()
    {
        while (true)
        {
            float countSeconds = Random.Range(7.0f, 12.0f);
            yield return new WaitForSeconds(countSeconds);
            Vector3 posToSpawn = new Vector3(Random.Range(-11.85f, 11.85f), 1, -0.1f);
            GameObject newBall = Instantiate(_specialBallprefab, posToSpawn, Quaternion.identity);
            newBall.transform.parent = _ballcontainer.transform;
            
        }
    }
*/

}
