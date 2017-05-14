using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    private Rigidbody rb;
	// Use this for initialization
	void Awake () {
	    rb = GetComponent<Rigidbody>();
	}

    void Start() {

        rb.AddTorque(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), ForceMode.VelocityChange);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
