using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject[] shapePrefabs;
    //private int score = 0;

   // [SerializeField] Text textScore;
    void Start()
    {
        //score = 0;
       // textScore.text = $"—чет: {score}";
       
        SpawnNextShape();
    }


    void Update()
    {

    }

    public void SpawnNextShape()
    {
        int index = Random.Range(0, shapePrefabs.Length);
        GameObject Shape = Instantiate(shapePrefabs[index], SpawnPoint.position, Quaternion.identity);

        index = Random.Range(0, 4);
        Shape.transform.eulerAngles = new Vector3(0, 0, 90 * index);
    }
}
