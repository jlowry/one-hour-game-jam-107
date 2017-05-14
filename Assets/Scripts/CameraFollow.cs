using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Vector3 offset;
    // Use this for initialization
    [SerializeField] private Transform target;

    void Awake () {
        offset = transform.position - target.position;
    }
	
	// Update is called once per frame
	void Update () {
	    transform.position = target.position + offset;
	}
}
