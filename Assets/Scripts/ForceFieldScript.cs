using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldScript : MonoBehaviour {
    public Vector3 forceVect;
    public Vector3 torqueVect;

    private bool isApplying = false;

    private void OnTriggerStay(Collider other) {
        Debug.Log("THOU HAST ENTERED ME LAIR");
        Rigidbody victim = other.GetComponent<Rigidbody>();
        Debug.Log(victim);
        if (victim != null) {
            victim.AddForce(forceVect);
            victim.AddTorque(torqueVect);
        }
    }
}