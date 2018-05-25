using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillPatty : MonoBehaviour
{

    public enum GrilledState {
        Rare,
        Welldone,
        OverCooked
    }
    public GrilledState currentState; 

    // Grilling Variables
    private bool isGrilling = false;
    public float GrilledScore;
    public int heatLevel;
    public float heatTimer;
    public float heatRare = 1;
    public int overCookedScore = 125;
    public int welldoneScore = 75;

    // Color Variables 
    public Color rareColor = new Color32(225, 93, 93, 255);
    public Color welldoneColor = new Color32(124, 97, 67, 255);
    public Color overCookedColor = new Color32(66, 66, 66, 255);

    // Use this for initialization
    void Start() {
        currentState = GrilledState.Rare;
    }

    // Update is called once per frame
    void Update() {
        if (isGrilling) {
            Grill();
        }
    }

    private void Grill() {
        // Heat the patty
        if (Time.time > heatTimer) {
            GrilledScore += heatLevel;
            heatTimer = Time.time + heatRare;
        }

        // Update the GrilledState depends on the GrilledScore
        if (GrilledScore > overCookedScore) {
            currentState = GrilledState.OverCooked;
            this.GetComponent<Renderer>().material.color = overCookedColor;
        } else if (GrilledScore > welldoneScore) {
            currentState = GrilledState.Welldone;
            this.GetComponent<Renderer>().material.color = welldoneColor;
        } else {
            currentState = GrilledState.Rare;
            this.GetComponent<Renderer>().material.color = rareColor;
        }
    }

    
    private void OnTriggerStay(Collider other) {
        if (other.tag == "GrillTop") {
            // Start Grilling
            isGrilling = true;
            heatLevel = other.GetComponent<GrillTop>().temperatureLevel;
        }
    }

    
    private void OnTriggerExit(Collider other) {
        if (other.tag == "GrillTop") {
            // Stop Grilling
            isGrilling = false;
        }
    }
}
