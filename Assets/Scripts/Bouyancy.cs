using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouyancy : MonoBehaviour
{
    [SerializeField]
    private float bouyancy = 1;

    private Rigidbody rb;
    private Bounds bounds;

    private bool inWater = false;
    private float surface;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bounds = GetComponent<BoxCollider>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (inWater)
        {
            // Bouyancy force
            float bottom = transform.position.y - (bounds.center.y + bounds.extents.y);
            rb.AddRelativeForce(bouyancy * (surface - bottom) * Vector3.up);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Bounds otherBounds = other.GetComponent<BoxCollider>().bounds;
        surface = other.transform.position.y + otherBounds.center.y + otherBounds.extents.y;
        inWater = true;
    }

    void OnTriggerExit(Collider other)
    {
        inWater = false;
    }
}
