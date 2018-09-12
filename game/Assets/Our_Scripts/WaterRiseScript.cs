using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRiseScript : MonoBehaviour {

    public Transform Planet;
    public Material PlanetMat;
    public Material PlanetMatO;


    private bool MatO = true;
    private WaterRiseEffect script_planet;

	// Use this for initialization
	void Start () {
        script_planet = Planet.GetComponent<WaterRiseEffect>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            script_planet.ChangeMat(PlanetMat);
        }
	}

    private void OnTriggerEnter(Collider other) {
        if(!transform.root.GetComponent<OVRGrabbable>().isGrabbed && other.CompareTag("Hand")) {
            if (MatO) {
                script_planet.ChangeMat(PlanetMat);
                MatO = false;
            } else {
                script_planet.ChangeMat(PlanetMatO);
                MatO = true;
            }
            
        }
    }
}
