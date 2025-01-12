using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckCollection : MonoBehaviour
{
    int duckCount;
    // Start is called before the first frame update
    void Start()
    {
        duckCount = 0;
    }

    public void AddDuck()
    {
        if(duckCount < 5)
        {
            Transform boatDuck = gameObject.transform.GetChild(duckCount);
            boatDuck.gameObject.SetActive(true);
            duckCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
