using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillersAndCastleParticleSystem : MonoBehaviour
{
    public GameObject particle;
    bool isHit = false, isSpawn = false;
    private void Update()
    {
        if (isHit && !isSpawn)
        {
            Destroy(Instantiate(particle, transform.position, Quaternion.identity),2);
            StartCoroutine(spwanned());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnowBall"))
        {
            isHit = true;
        }
    }
    IEnumerator spwanned()
    {
        yield return new WaitForSeconds(0.2f);
        isSpawn = true;
    }
}
