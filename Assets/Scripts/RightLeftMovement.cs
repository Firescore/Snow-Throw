using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftMovement : MonoBehaviour
{
    private Touch touch;
    private float moveSpeed = 0.01f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * moveSpeed, transform.position.y, transform.position.z);
            }
        }
        if(transform.position.x >= 1.1f)
        {
            transform.position = new Vector3(1.1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -1.1f)
        {
            transform.position = new Vector3(-1.1f, transform.position.y, transform.position.z);
        }
    }
}
