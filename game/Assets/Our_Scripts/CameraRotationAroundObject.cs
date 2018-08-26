using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationAroundObject : MonoBehaviour
{

    public Transform Target;
    public float Speed = 1;
    public float smoothTime = 0.03f;

    private bool mouseIsPressed = false;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) mouseIsPressed = true;
        else if (Input.GetMouseButtonUp(0)) mouseIsPressed = false;
    }

    // Update is called once per frame
	void LateUpdate () {
	    if (mouseIsPressed)
	    {
	        /*transform.RotateAround(Target.position, transform.right, -Input.GetAxis("Mouse Y") * Speed);
	        transform.RotateAround(Target.position, transform.up, Input.GetAxis("Mouse X") * Speed);*/

	        Vector3 targetPosition = Target.TransformPoint(Input.GetAxis("Mouse X") * Speed, -Input.GetAxis("Mouse Y") * Speed, 2);

	        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            transform.LookAt(transform);
	    }
    }
}
