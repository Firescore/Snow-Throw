using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnowBall : MonoBehaviour
{
    public static SnowBall snb;
    Rigidbody rb;
    public float incrementSpeed = 0.5f;
    public float decreseSpeed = 0.5f;
    public bool isHitCastle = false;
    public bool isThrown = false;
    public GameObject snowParticle;

    private bool Test=false;


    private void Start()
    {
        snb = this;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        if (!GameManager.gm.R_Down && !GameManager.gm.isFinishLineCrossed)
        {
            if (GameManager.gm.isMousePressed && GameManager.gm.R_Left && !Test)
            {
                transform.localScale += new Vector3(incrementSpeed, incrementSpeed, incrementSpeed) * Time.deltaTime;
                rb.isKinematic = true;
                Test = true;
            }
            else if(GameManager.gm.isMousePressed)
            {
                transform.localScale += new Vector3(incrementSpeed, incrementSpeed, incrementSpeed) * Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(0) && !isThrown && !GameManager.gm.R_Left)
            {
                transform.parent = null;
                rb.AddForce(Vector3.back * 25, ForceMode.Impulse);
                Destroy(gameObject, 2f);
                StartCoroutine(snow());
                isThrown = true;
            }
            if (Input.GetMouseButtonUp(0) && !isThrown && GameManager.gm.R_Left)
            {
                transform.parent = null;
                rb.isKinematic = false;
                rb.AddForce(Vector3.right * 25, ForceMode.Impulse);
                Destroy(gameObject, 2);
                StartCoroutine(snow());
                isThrown = true;
            }
        }
        if (!GameManager.gm.R_Down)
        {
            rb.isKinematic = false;
        }
        if (GameManager.gm.R_Down && !GameManager.gm.isFinishLineCrossed)
        {
            if (GameManager.gm.isMousePressed)
            {
                rb.isKinematic = true;
                transform.localScale += new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(0) && !isThrown && GameManager.gm.R_Left)
            {
                transform.parent = null;
                rb.isKinematic = false;
                rb.AddForce(Vector3.right * 25, ForceMode.Impulse);
                Destroy(gameObject, 2);
                StartCoroutine(snow());
                isThrown = true;
            }
        }
        if (GameManager.gm.isFinishLineCrossed)
        {
            if (!isThrown && GameManager.gm.R_Left)
            {
                transform.parent = null;
                rb.AddForce(Vector3.right * 25, ForceMode.Impulse);
                isThrown = true;
            }
            if (isThrown)
            {
                transform.localScale -= new Vector3(decreseSpeed, decreseSpeed, decreseSpeed) * Time.deltaTime;
            }
            if(transform.localScale.magnitude <= 1f)
            {
                Destroy(Instantiate(snowParticle, transform.position, Quaternion.identity), 1f);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("castle"))
        {
            isHitCastle = true;
            Destroy(Instantiate(snowParticle, transform.position, Quaternion.identity), 1f);
            Destroy(gameObject, 0.1f);
        }
        if (collision.gameObject.CompareTag("Charecter"))
        {
            Destroy(gameObject, 0.1f);
            Destroy(Instantiate(snowParticle, transform.position, Quaternion.identity), 1f);
            Destroy(collision.gameObject, 2.5f);
        }

    }

    IEnumerator snow()
    {
        yield return new WaitForSeconds(1.9f);
        Destroy(Instantiate(snowParticle, transform.position, Quaternion.identity), 1f);
    }
   
}
