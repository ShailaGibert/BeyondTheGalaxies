using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShip : MonoBehaviour
{
    private Rigidbody rig;
    public float speed;
    void Awake()
    {
        rig=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
        rig.velocity=transform.forward*speed;
    }
}
