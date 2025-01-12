using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouyancy : MonoBehaviour
{
    [SerializeField]
    private float bouyancy = 1;
    [SerializeField]
    private Transform water;

    [Header("Bobbing Animation")]
    [Tooltip("Amplitude of sinusoidal force driving the bobbing animation")]
    [SerializeField]
    private float amplitude = 2;
    [Tooltip("Period in seconds of sinusoidal force driving the bobbing animation")]
    [SerializeField]
    private float period = 5;

    private Rigidbody rb;
    private float bottomExtent;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Bounds bounds = GetComponent<BoxCollider>().bounds;
        bottomExtent = bounds.center.y + bounds.extents.y;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float bottom = transform.position.y - bottomExtent;
        if (water.position.y > bottom)
        {
            // Bouyancy force
            rb.AddRelativeForce(bouyancy * (water.position.y - bottom) * Vector3.up);

            // Bobbing up and down animation
            rb.AddRelativeForce(amplitude * Mathf.Sin(2 * Mathf.PI / period * time) * Vector3.down);
            time += Time.deltaTime;
        }
    }
}
