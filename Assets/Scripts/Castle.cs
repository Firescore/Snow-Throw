using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public List<GameObject> childObject = new List<GameObject>();
    public bool isHitCastle = false;
    void Start()
    {
        foreach (Transform child in transform)
        {
            childObject.Add(child.gameObject);
        }
        for (int i = 0; i < childObject.Count; i++)
        {
            childObject[i].GetComponent<Rigidbody>().isKinematic = enabled;
        }
    }
    private void Update()
    {
        if (isHitCastle)
        {
            for (int i = 0; i < childObject.Count; i++)
            {
                childObject[i].GetComponent<Rigidbody>().isKinematic = false;
                childObject[i].GetComponent<Rigidbody>().useGravity = true;
                if (childObject.Count == childObject.Count - 1)
                {
                    isHitCastle = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnowBall"))
        {
            isHitCastle = true;
            Destroy(this.gameObject, 1f);
        }
    }
}
