using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{

    public float Speed = 1;

	// Update is called once per frame
	void Update ()
	{
	    Vector3 rotation = new Vector3(0, -Speed * Time.deltaTime, 0);
		transform.Rotate(rotation);
	}
}
