using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ColliderChecker : MonoBehaviour
{
    Rigidbody rb;
    bool isBallHit = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
    }

    private void Update()
    {
        if (isBallHit)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            isBallHit = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SnowBall"))
        {
            isBallHit = true;
        }
    }
}
