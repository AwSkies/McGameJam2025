using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private float v_hover;                      // Transition in-out visual fx
    private int ducks;                          // # of ducks collected
    private Vector2 coords;                     // position of boat on map
    private bool ui_active = false;

    public GameObject o_duck;
    public GameObject o_mapmask;
    public GameObject o_scroll;
    public GameObject o_arrow;

    private RectTransform mask;
    private RectTransform scroll;
    private RectTransform arrow;
    private GameObject[] ducklist = new GameObject[5];
    
    // Getter function: returns boolean indicating if UI is on.
    public bool IsActive(){
        return ui_active;
    }

    // Setter function: toggles on/off the UI.
    public void ToggleUI(){
        ui_active = !ui_active;
    }

    // Getter function: returns number of ducks collected.
    public int GetDucks(){
        return ducks;
    }

    // Setter function: increments duck counter by 1.
    public void AddDuck(){
        if (ducks < 5)
        {
            ducklist[ducks].GetComponent<DuckUI>().show = true;
            ducks++;
        }
    }

    // Setter function: sets the player's coordinates to _x, _y.
    public void SetCoords(float _x, float _y){
        coords.x = _x;
        coords.y = _y;
    }

    // Start is called before the first frame update
    void Start()
    {
        v_hover = 0f;
        ducks = 0;
        coords = new Vector2(0,0);
        ui_active = false;
        mask = o_mapmask.GetComponent<RectTransform>();
        scroll = o_scroll.GetComponent<RectTransform>();
        arrow = o_arrow.GetComponent<RectTransform>();
        for (int _i = 0; _i < 5; _i++){
            ducklist[_i] = Instantiate(o_duck, new Vector3(730 + 80 * _i, 180 - 80 * ((_i+1) % 2), 0), Quaternion.Euler(0, 0, 0), transform);
            Debug.Log(_i);
            DuckUI _script = ducklist[_i].GetComponent<DuckUI>();
            _script.num = _i;
            if (_i < ducks){_script.show = true;}
            _script.DuckInit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ui_active){v_hover = ((1 / Time.deltaTime / 7) * v_hover + 1)/(1 / Time.deltaTime / 7 + 1);}
        else {v_hover = (1 / Time.deltaTime / 7)*v_hover/(1 / Time.deltaTime / 7 + 1);}

        mask.sizeDelta = new Vector2(v_hover * 540f,540f);
        mask.position = new Vector3(v_hover * 270f, 270, 0);
        scroll.position = new Vector3(v_hover * 640f - 50f, 270f, 0);
        arrow.position = new Vector3(coords.x + 270, coords.y + 285, 0);
        arrow.localEulerAngles += new Vector3(0, 120, 0) * Time.deltaTime;

        foreach (GameObject _duck in ducklist){
            if (_duck != null){
                DuckUI _script = _duck.GetComponent<DuckUI>();
                _duck.transform.position = new Vector3(_script.init_pos.x, 200 + (v_hover * (_script.init_pos.y - 400) + 400), 0);
            }
        }
    }

    void OnMap()
    {
        ToggleUI();
    }
}
