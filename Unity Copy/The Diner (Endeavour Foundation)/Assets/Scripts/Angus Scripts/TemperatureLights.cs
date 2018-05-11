using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureLights : MonoBehaviour {

    public GameObject[] temperatureLights;

    public GameObject grillTop;

	// Use this for initialization
	void Start () {
        int totalLights = temperatureLights.Length;
        for (int i = 0; i < totalLights; i++) {
            temperatureLights[i].GetComponent<TemperatureLight>().lightID = i;
            int green = (totalLights - 1 - i) * 255 / totalLights;
            temperatureLights[i].GetComponent<TemperatureLight>().onColor = new Color32(255, (byte)green, 0, 255);
        }

	}
	
	// Update is called once per frame
	void Update () {
        ChangeLightState();
    }

    // Turn on the lights depends on the temperatureLevel
    private void ChangeLightState() {
        int currentTempLevel = grillTop.GetComponent<GrillTop>().temperatureLevel;
        for (int i = 0; i< temperatureLights.Length; i++) {
            if (i < currentTempLevel) {
                temperatureLights[i].GetComponent<TemperatureLight>().currentState = TemperatureLight.LightState.On;
            } else {
                temperatureLights[i].GetComponent<TemperatureLight>().currentState = TemperatureLight.LightState.Off;
            }
        }
    }
}
