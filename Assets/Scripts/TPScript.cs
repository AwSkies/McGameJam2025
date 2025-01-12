using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScript : MonoBehaviour
{
    [SerializeField]
    GameObject Correspondant;

    private Vector3 coords;

    static private int debounce = 0;

    // Start is called before the first frame update
    void Start()
    {
        coords = Correspondant.transform.position;    
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collidedd");
        if (debounce < 1)
        {
            Debug.Log("THOU ART TELEPORT");
            other.transform.position = coords;
            debounce = 2;
        }
    }

    void OnTriggerExit(Collider other)
    {
        debounce--;
    }
}
