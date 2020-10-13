using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charecter : MonoBehaviour
{
    public float start, end;
    public float speed = 1f;
    public bool reachStart = true, rechEnd = false, hitBall=false;

    public bool activeRun = false;
    public Animator anime;

    void Update()
    {
        if (activeRun)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (reachStart && !rechEnd)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            if (!reachStart && rechEnd)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            if (transform.position.x <= end)
            {
                reachStart = false;
                rechEnd = true;
            }
            if (transform.position.x >= start)
            {
                reachStart = true;
                rechEnd = false;
            }
        }
        
        if (hitBall)
        {
            anime.SetBool("dead", true);
            Destroy(this.gameObject, 1.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnowBall"))
        {

            hitBall = true;
        }
    }
}
