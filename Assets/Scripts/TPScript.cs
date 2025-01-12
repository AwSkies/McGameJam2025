using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScript : MonoBehaviour {
    [SerializeField]
    GameObject Correspondant;

    private Vector3 coords;

    static private int debounce = 0;

    private int time = 0;
    private bool canTime = true;

    public int maxTime;

    // Start is called before the first frame update
    void Start() {
        coords = Correspondant.transform.position;
    }

    private IEnumerator Timer() {
        yield return new WaitForSeconds(1f);
        time++;
        canTime = true;
    }

    void OnTriggerStay(Collider other) {
        if (canTime) {
            canTime = false;
            StartCoroutine(Timer());
        }
        //Debug.Log("Collidedd");
        if (time > maxTime && debounce < 1) {
            //Debug.Log("THOU ART TELEPORT");
            other.transform.position = coords;
            debounce = 2;
        }
    }

    void OnTriggerExit(Collider other) {
        debounce--;
        time = 0;
    }
}