using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    public GameObject Player, SnowBall;
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
            GameManager.gm.R_Down = false;
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);
            Player.transform.position = new Vector3(Player.transform.position.x, -6.5f, Player.transform.position.z);
            cF.Offset = new Vector3(-16f, 0f, 0f);
        }
        if (other.gameObject.CompareTag("R+15"))
        {
            GameManager.gm.R_Down = true;
            Player.transform.rotation = Quaternion.Euler(15, 90, 0);
            cF.Offset = new Vector3(-16f, 3.3f, 0f);
        }
        if (other.gameObject.CompareTag("R+90"))
        {
            GameManager.gm.R_Left = true;
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);
            Player.transform.position = new Vector3(Player.transform.position.x, 5.98f, Player.transform.position.z);
            cF.Offset = new Vector3(-19f, 3.38f, 0f);
        }
        if (other.gameObject.CompareTag("FinishLine"))
        {
            GameManager.gm.isFinishLineCrossed = true;
        }
    }
    

    
}
