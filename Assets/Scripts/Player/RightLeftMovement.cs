using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftMovement : MonoBehaviour
{
    private Touch touch;
    private float moveSpeed = 0.01f, turnInput, turnStrength = 90f;

    private void Update()
    {

        if (!GameManager.gm.R_Left)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * moveSpeed, transform.position.y, transform.position.z);
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, transform.position.y + touch.deltaPosition.x * turnStrength * Time.deltaTime, 0));
                }
            }
            if (transform.position.x >= 5f)
            {
                transform.position = new Vector3(5f, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= 0f)
            {
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            }
        }
        if (GameManager.gm.R_Left)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + touch.deltaPosition.x * moveSpeed);
                    // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, transform.position.y + touch.deltaPosition.x * turnStrength * Time.deltaTime, 0));
                }
            }
            if (transform.position.z >= -128.7f)
            {
                transform.position = new Vector3(-128.7f, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -134f)
            {
                transform.position = new Vector3(-134f, transform.position.y, transform.position.z);
            }
        }
        turnInput = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0));
    }
}
