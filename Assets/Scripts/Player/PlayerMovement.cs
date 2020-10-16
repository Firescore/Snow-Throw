using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement pm;
    public float speed = 5f;
    public CFX_AutoRotate rot;
    public GameObject SnowBall, Player,SnowBallData, Snow;
    public Transform snowBall;

    public bool snowBallSpwan = false;
    private void Update()
    {
        if (!GameManager.gm.isFinishLineCrossed)
        {
            if (GameManager.gm.isMousePressed && rot != null)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                rot.enabled = true;
            }
            else
            {
                if (rot != null)
                {
                    rot.enabled = false;
                }

            }
            if (GameManager.gm.isMousePressed && !snowBallSpwan && rot == null)
            {
                Snow = Instantiate(SnowBall, snowBall.position, Quaternion.identity);
                Snow.transform.parent = Player.transform;
                SnowBallData = Snow;
                rot = Snow.GetComponent<CFX_AutoRotate>();
                snowBallSpwan = true;
            }
            if (Input.GetMouseButtonUp(0) && snowBallSpwan)
            {
                snowBallSpwan = false;
            }
        }
    }
        

}
