using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private Rigidbody rig;


    void Awake() {

        rig = GetComponent<Rigidbody>();
    
    }



    // Start is called before the first frame update
    void Start() {

        Vector3 angularVelocity = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        rig.angularVelocity = angularVelocity;
        
    }

 
}
