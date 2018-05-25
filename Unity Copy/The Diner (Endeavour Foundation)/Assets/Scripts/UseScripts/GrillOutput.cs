using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrillOutput : MonoBehaviour {
    public GameObject rimUpper;
    public GameObject rimLower;
    public GameObject rimLeft;
    public GameObject rimRight;

    public GameObject score;

    public Material inprogress;
    public Material complete;

    public float numCount = 0;
    float winCount = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (numCount > 0)
        {
            rimUpper.GetComponent<Renderer>().material = inprogress;
            rimLower.GetComponent<Renderer>().material = inprogress;
            rimRight.GetComponent<Renderer>().material = inprogress;
            rimLeft.GetComponent<Renderer>().material = inprogress;

            score.GetComponent<TextMeshPro>().text = numCount+"/10 Perfect Patties";
        }

        if (numCount >= winCount)
        {
            rimUpper.GetComponent<Renderer>().material = complete;
            rimLower.GetComponent<Renderer>().material = complete;
            rimRight.GetComponent<Renderer>().material = complete;
            rimLeft.GetComponent<Renderer>().material = complete;

            score.GetComponent<TextMeshPro>().text = "Done!";
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PattyCooked")
        {
            numCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PattyCooked")
        {
            numCount--;
        }
    }
}
