using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public bool isMousePressed = false;

    public bool R_Left = false;
    public bool R_Down = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isMousePressed = true;
        }
        else
        {
            isMousePressed = false;
        }
    }
}
