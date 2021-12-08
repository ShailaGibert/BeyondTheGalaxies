using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody rig;
    
    void Awake()
    {

        rig = GetComponent<Rigidbody>();

    }



    // Start is called before the first frame update
    void Start()
    {

        //Vector3 angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized;

        Vector3 angularVelocity = Random.insideUnitSphere;
        //rig.angularVelocity = angularVelocity * tumble;
        rig.angularVelocity = Random.insideUnitSphere * tumble;

    }

}
