﻿using UnityEngine;

public class BoidController : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 20;
    public GameObject prefab;
    public GameObject chasee;
 
    public Vector3 flockCenter;
    public Vector3 flockVelocity;
 
    private GameObject[] boids;
 
    void Start()
    {
        boids = new GameObject[flockSize];
        for (var i=0; i<flockSize; i++)
        {
            Vector3 position = new Vector3 (
                Random.value * collider.bounds.size.x,
                Random.value * collider.bounds.size.y,
                Random.value * collider.bounds.size.z
            ) - collider.bounds.extents;
 
            GameObject boid = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<BoidFlocking>().SetController (gameObject);
            boids[i] = boid;
        }
    }

    private void Update ()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;
 
        foreach (GameObject boid in boids)
        {
            theCenter = theCenter + boid.transform.localPosition;
            theVelocity = theVelocity + boid.rigidbody.v;
        }
 
        flockCenter = theCenter/(flockSize);
        flockVelocity = theVelocity/(flockSize);
    }
}