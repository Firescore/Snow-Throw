using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnowBall : MonoBehaviour
{
    public static SnowBall snb;
    Rigidbody rb;
    public bool isHitCastle = false;
    public bool isThrown = false;
    public GameObject snowParticle;


    private void Start()
    {
        snb = this;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!GameManager.gm.R_Down)
        {
            if (GameManager.gm.isMousePressed)
            {
                transform.localScale += new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(0) && !isThrown && !GameManager.gm.R_Left)
            {
                rb.AddForce(Vector3.back * 25, ForceMode.Impulse);
                Destroy(gameObject, 1.5f);
                isThrown = true;
            }
            if (Input.GetMouseButtonUp(0) && !isThrown && GameManager.gm.R_Left)
            {
                rb.AddForce(Vector3.right * 25, ForceMode.Impulse);
                Destroy(gameObject, 2);
                isThrown = true;
            }
        }
        if (GameManager.gm.R_Down)
        {
            if (GameManager.gm.isMousePressed)
            {
                rb.isKinematic = true;
                transform.localScale += new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(0) && !isThrown && GameManager.gm.R_Left)
            {
                rb.isKinematic = false;
                rb.AddForce(Vector3.right * 25, ForceMode.Impulse);
                Destroy(gameObject, 2);
                isThrown = true;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pillers"))
        {
            Destroy(gameObject, 0.1f);
            Destroy(Instantiate(snowParticle,transform.position,Quaternion.identity), 1f);
            Destroy(collision.gameObject.transform.parent.gameObject, 2.5f);
        }
        if (collision.gameObject.CompareTag("castle"))
        {
            isHitCastle = true;
            Destroy(Instantiate(snowParticle, transform.position, Quaternion.identity), 1f);
        }
        
    }
   
}
