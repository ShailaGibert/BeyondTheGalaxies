using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rig;

    [Header("Shooting")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start(){

        UpdateBoundary();
    }
    void UpdateBoundary(){

        Vector2 half = Utils.GetDimensionsInWorldUnits() /2;
        boundary.xMin= -half.x +0.5f;
        boundary.xMax= half.x -0.5f;
        boundary.zMin= -half.y+6.3f;
        boundary.zMax= half.y+ 1.0f;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));
        rig.rotation = Quaternion.Euler(0, 180, rig.velocity.x * tilt);
    }
}
