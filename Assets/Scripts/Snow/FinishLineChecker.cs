using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineChecker : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("2X"))
        {
            GameManager.gm.Ponts[0] = true;
        }
        if (other.gameObject.CompareTag("3X"))
        {
            GameManager.gm.Ponts[1] = true;
        }
        if (other.gameObject.CompareTag("4X"))
        {
            GameManager.gm.Ponts[2] = true;
        }
        if (other.gameObject.CompareTag("5X"))
        {
            GameManager.gm.Ponts[3] = true;
        }
        if (other.gameObject.CompareTag("6X"))
        {
            GameManager.gm.Ponts[4] = true;
        }
        if (other.gameObject.CompareTag("7X"))
        {
            GameManager.gm.Ponts[5] = true;
        }
        if (other.gameObject.CompareTag("8X"))
        {
            GameManager.gm.Ponts[6] = true;
        }
    }
}
