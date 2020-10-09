using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

}
