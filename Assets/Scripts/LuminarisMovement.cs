using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminarisMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rig;

    /*// Prueba! borrar si no funciona
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;*/

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

    /*//Prueba para que nave suba y baje / Borrar si no funciona
    void Start()
    {
        
        StartCoroutine(UpAndDown());
    }

    IEnumerator UpAndDown()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            rig.velocity = transform.up * speed;
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            rig.velocity = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }*/

}