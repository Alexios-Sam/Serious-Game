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
    public float RotationSpeed = 10;
    public float TempSpeed = 1;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private bool grabbingTarget;
    [SerializeField]
    private bool touchingTarget;

    private Vector3 lastHandPosition;


    private void Start() {
        lastHandPosition = transform.position;
    }

    /*private void FixedUpdate() {
        RotateObject();
    }*/

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
            if (!grabbingTarget) {
                CancelInvoke();
            }
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
            InvokeRepeating("CheckForRelease", 0.0f, 0.1f);
            InvokeRepeating("RotateObject", 0.0f, 0.1f);
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
        //Times RotationSpeed (100) to make the position difference bigger so it can be registered properly
        Vector3 positionDifference = transform.position * RotationSpeed - lastHandPosition * RotationSpeed;

        var currentRot = Quaternion.Euler(target.rotation.eulerAngles);
        var targetRot = Quaternion.Euler(positionDifference);
        Quaternion.RotateTowards(currentRot, targetRot, Time.deltaTime * TempSpeed);

        lastHandPosition = transform.position;
    }

    //target.Rotate(Vector3.up, -positionDifference.x);
    //target.Rotate(Vector3.right, positionDifference.y);
}
