using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandEarthRotationScript : MonoBehaviour
{
    public OVRInput.Controller Controller;
    public OVRInput.Axis1D Trigger;
    [Range(0.0f, 1.0f)]
    public float GrabTolerance = 0.75f;
    [Range(0.0f, 1.0f)]
    public float ReleaseTolerance = 0.25f;


    private Transform target;
    private static bool grabbingTarget;
    private bool touchingTarget;

    private Vector3 lastHandPosition;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rotatable"))
        {
            touchingTarget = true;
            if (!grabbingTarget)
            {
                target = other.transform;
                InvokeRepeating("CheckForGrab", 0.0f, 0.1f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rotatable"))
        {
            touchingTarget = false;
            if(OVRInput.Get(Trigger, Controller) <= ReleaseTolerance)
            {
                target = null;
            }
        }
    }

    private void CheckForGrab()
    {
        if (OVRInput.Get(Trigger, Controller) >= GrabTolerance)
        {
            grabbingTarget = true;
            CancelInvoke();
            lastHandPosition = transform.position;
            InvokeRepeating("CheckForRelease", 0.0f, 0.01f);
            InvokeRepeating("RotateObject", 0.0f, 0.05f);
        }
    }

    private void CheckForRelease()
    {
        if (OVRInput.Get(Trigger, Controller) <= ReleaseTolerance)
        {
            grabbingTarget = false;
            CancelInvoke();
            if (!touchingTarget) target = null;
        }
    }

    private void RotateObject()
    {
        //Rotating object
        float x = transform.position.x - lastHandPosition.x;
        float y = transform.position.y - lastHandPosition.y;
        float z = transform.position.z - lastHandPosition.z;

        Vector3 rotation = new Vector3(x, y, z);
        target.Rotate(rotation);

        lastHandPosition = transform.position;
    }

}
