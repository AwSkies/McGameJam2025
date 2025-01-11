using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform boat;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - boat.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = boat.position + offset;
    }
}
