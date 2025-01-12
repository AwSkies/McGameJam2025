using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    public int num = 0;
    public bool show = false;
    public Vector3 init_pos;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void DuckInit(){
        init_pos = transform.position;
        image = GetComponent<Image>();

        image.sprite = Resources.Load<Sprite>("Sprites/Duck" + num.ToString());
        Debug.Log(image.sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (show){image.color = new Color(1, 1, 1, 1);}
        else {image.color = new Color(0, 0, 0, 0.5f);}
    }
}
