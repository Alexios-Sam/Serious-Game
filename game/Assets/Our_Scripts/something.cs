using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class something : MonoBehaviour {

    public TextMesh text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        text.gameObject.SetActive(false);
    }
}
