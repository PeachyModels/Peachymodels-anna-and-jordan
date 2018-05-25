using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureLight : MonoBehaviour {

    public int lightID;

    public Color onColor;
    public Color offColor;

    public enum LightState {      
        Off,
        On,
    }
    public LightState currentState;

	// Use this for initialization
	void Start () {
        offColor = this.GetComponent<Renderer>().material.color;
        currentState = LightState.Off;
    }
	
	// Update is called once per frame
	void Update () {
        CheckCurrentState();
    }

    // Change lights color depents on it state
    private void CheckCurrentState() {
        switch (currentState) {
            case LightState.On:
                this.GetComponent<Renderer>().material.color = onColor;
                break;
            case LightState.Off:
                this.GetComponent<Renderer>().material.color = offColor;
                break;
        }
    }
}
