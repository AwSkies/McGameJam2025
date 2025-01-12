using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tides : MonoBehaviour
{
    public float maxY;
    public float minY;
    public bool ascending;
    public float speed;
    public float pos;

    public void Update() {
        if (transform.localPosition.y >= maxY) {
            ascending = false;
        }
        if (transform.localPosition.y <= minY) {
            ascending = true;
        }

        if (ascending) {
            transform.localPosition += new Vector3(0f, speed , 0f);
        } else {
            transform.localPosition -= new Vector3(0f, speed, 0f);
        }
        pos = transform.localPosition.y;
    } 
}
