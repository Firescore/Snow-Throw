using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    public GameObject Player;
    public CameraFollow cF;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("R-15"))
        {
            Player.transform.rotation = Quaternion.Euler(-15, 180, 0);
        }
        if (other.gameObject.CompareTag("R-0"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (other.gameObject.CompareTag("R-0-2"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);
            Player.transform.position = new Vector3(Player.transform.position.x, -6.5f, Player.transform.position.z);
            cF.Offset = new Vector3(-16f, 0f, -8f);
            cF.Offset = new Vector3(-16f, 0f, -8f);
        }
        if (other.gameObject.CompareTag("R+15"))
        {
            Player.transform.rotation = Quaternion.Euler(15, 90, 0);
            cF.Offset = new Vector3(-16f, 7f, -8f);
        }
        if (other.gameObject.CompareTag("R+90"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);
            Player.transform.position = new Vector3(Player.transform.position.x, 5.98f, Player.transform.position.z);
            cF.Offset = new Vector3(-16f, 0f, -8f);
        }
    }
}
