using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;

    // Start is called before the first frame update
    void Start()
    {
        SpawnShip();
    }

    // Update is called once per frame
    void SpawnShip()
    {
        Vector3 spawPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(hazard, spawPosition, Quaternion.identity);
    }
}
