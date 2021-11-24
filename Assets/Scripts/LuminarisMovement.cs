using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminarisMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rig.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}