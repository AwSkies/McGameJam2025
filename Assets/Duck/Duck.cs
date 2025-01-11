using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    Dictionary<int, string> ducks = new Dictionary<int, string>();

    public void Remove(int index)
    {
        if (ducks.ContainsKey(index))
            ducks.Remove(index);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
