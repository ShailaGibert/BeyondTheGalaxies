using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWaves();
    }

    // Update is called once per frame
    void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Instantiate(hazard, spawnPosition, Quaternion.identity);
    }
}
