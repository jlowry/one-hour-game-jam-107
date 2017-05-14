using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float speed = 4.0F;
    public float turnSpeed = 180F;

    private Transform camera;
	// Use this for initialization
	void Awake () {
	    camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
	    //var v = Input.GetAxis("vertical");

	    //var rotation = new Vector3(0.5f * v, 0f, 0f );

	    var change = transform.forward * speed * Time.deltaTime;
        //transform.Rotate(-Input.GetAxis("Vertical") * speed, Input.GetAxis("Horizontal") * speed, 0.0f);
	    Move();
        transform.position += change;
       
	}

    void Move() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // calculate move direction to pass to character
    
            // calculate camera relative direction to move:
        var m_CamForward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
        var move = v * m_CamForward + h * camera.right;
       

        // pass all parameters to the character control script
        if (move.magnitude > 1f) move.Normalize();
        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, Vector3.up);
        var m_TurnAmount = Mathf.Atan2(move.x, move.z);
        var m_ForwardAmount = move.z;
        // help the character turn faster (this is in addition to root rotation in the animation)
        //float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }
}
