using UnityEngine;
using System.Collections;

// Cartoon FX  - (c) 2015 Jean Moreno

// Indefinitely rotates an object at a constant speed

public class CFX_AutoRotate : MonoBehaviour
{
	// Rotation speed & axis
	public Vector3 rotation;
	
	// Rotation space
	public Space space = Space.Self;
	
	void Update()
	{
        if (!GameManager.gm.R_Left)
        {
            rotation = new Vector3(-90, 0, 0);
        }
        if (GameManager.gm.R_Left)
        {
            rotation = new Vector3(0, 0, -90);
        }
        this.transform.Rotate(rotation * Time.deltaTime, space);
	}
   IEnumerator rotate()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
