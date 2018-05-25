using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillTop : MonoBehaviour {

    public int temperatureLevel;
    public int maxTemperatureLevel = 10;
    public int minTemperatureLevel = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TemperatureUp() {
        if (temperatureLevel < maxTemperatureLevel) {
            temperatureLevel++;
        }
    }

    public void TemperatureDown() {
        if (temperatureLevel > minTemperatureLevel) {
            temperatureLevel--;
        }
    }
}
