using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("R-15"))
        {
            Player.transform.rotation = Quaternion.Euler(-15, 180, 0);
        }
        if (other.gameObject.CompareTag("R+15"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (other.gameObject.CompareTag("R+90"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
