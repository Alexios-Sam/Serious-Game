using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRiseEffect : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMat(Material planetMat) {
        transform.GetComponent<Renderer>().material = planetMat;
        transform.GetComponent<Planet>().PlanetMaterial = planetMat;
        transform.GetComponent<Planet>().InitMaterial(planetMat);
    }
}
