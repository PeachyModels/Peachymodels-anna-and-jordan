using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxVrCamera : MonoBehaviour {

    float accel = 0.1f;
    float deccel = -0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, accel);
        }
        else if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, deccel);
        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(deccel, 0, 0);
        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(accel, 0,0);
        }
    }
}
