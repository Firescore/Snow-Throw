using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private Touch touch;
    public float moveSpeed = 0.01f;
    public Slider slider;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float t = 0;
    // Update is called once per frame
    void Update()
    {
        t = Input.touchCount;
        text.text = t.ToString();
        moveSpeed = slider.value;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * moveSpeed, transform.position.y, transform.position.z + touch.deltaPosition.y * moveSpeed);
            }
        }
    }
}
