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
    [Header("Camera")]
    [SerializeField]
    private float radius;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private AudioSource motorSound;

    private Rigidbody rb;
    private Transform cam;

    private float power;
    private float turn;
    private Vector2 delta;
    private float camX;
    private float camY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(power * speed * Vector3.forward);

        if (power > 0) {
            motorSound.Play();
        }
        rb.AddRelativeTorque(turn * turnSpeed * Vector3.up);

        camX += delta.x;
        camY += delta.y;

        camY = Mathf.Clamp(camY, -maxHeight, maxHeight);

        Vector3 direction = new Vector3(0, 0, -radius);
        Quaternion rotation = Quaternion.Euler(-camY, camX, 0);

        cam.position = transform.position + rotation * direction;
        

        cam.LookAt(transform.position);
    }

    void OnPower(InputValue input)
    {
        power = input.Get<float>();
    }

    void OnSteer(InputValue input)
    {
        turn = input.Get<float>();
    }

    void OnLook(InputValue input)
    {
        delta = input.Get<Vector2>() * sensitivity;
    }
}
