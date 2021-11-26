using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    public float dodge;     // Velocidad m�xima de la maniobra evasiva
    public float smoothing;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public float tilt;

    private float targetManeuver;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //UpdateBoundary();
        StartCoroutine(Evade());
    }

    /*void UpdateBoundary()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        boundary.xMin = -half.x + 0.7f;
        boundary.xMax = half.x - 0.7f;
        boundary.zMin = 0;
        boundary.zMax = 0;
    }*/

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, rb.velocity.z);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        rb.rotation = Quaternion.Euler(90, 180, rb.velocity.x * tilt);
    }
}
