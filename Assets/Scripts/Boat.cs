using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boat : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;

    private Rigidbody rb;

    private float power;
    private float turn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(power * speed * Vector3.forward);
        rb.AddRelativeTorque(turn * turnSpeed * Vector3.up);
    }

    void OnPower(InputValue input)
    {
        power = input.Get<float>();
    }

    void OnSteer(InputValue input)
    {
        turn = input.Get<float>();
    }
}
