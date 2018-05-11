using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillControlButton : MonoBehaviour {

    public enum ControlButtons {
        DownButton,
        UpButton
    }
    
    public GameObject grillTop;

    public ControlButtons thisButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Pressed by Controller
    void OnTriggerStay(Collider other) {
        if (other.tag == "Controller") {
            if (other.GetComponent<Hand>().controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
                switch (thisButton) {
                    case ControlButtons.DownButton:
                        grillTop.GetComponent<GrillTop>().TemperatureDown();
                        break;
                    case ControlButtons.UpButton:
                        grillTop.GetComponent<GrillTop>().TemperatureUp();
                        break;
                }
            }
        }
    }

}
