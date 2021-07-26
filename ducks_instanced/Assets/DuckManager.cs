using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    [SerializeField]
    private  GameObject duck;

    [SerializeField]
    private Vector2[] spawnPoints;

    [SerializeField]
    private int totalDucks = 10;



    void Start()
    {
        Application.targetFrameRate = 600;

        for (int i = 0; i <= totalDucks; i++) {
            Vector2 position = GetRandomSpawn();
            GameObject gameObject = Instantiate(duck, position, Quaternion.identity);
        }
    }

    private Vector2 GetRandomSpawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[spawnIndex];
    }
}
