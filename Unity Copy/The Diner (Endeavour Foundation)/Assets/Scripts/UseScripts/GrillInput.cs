using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrillInput : MonoBehaviour {

    public GameObject pattyPrefab;

    public bool pattyStart = false;
    private bool scoreStart = true;

    public GameObject score;

    public float maxPatty = 20;
    public float numPatty = 0;
	
	// Update is called once per frame
	void Update () {

        if (pattyStart == true)
        {
            if (scoreStart == true)
            {
                score.GetComponent<TextMeshPro>().text = "0/10 Perfect Patties";
                scoreStart = false;
            }

            if (numPatty < maxPatty)
            {
                GameObject pattyObj = (GameObject)Instantiate(pattyPrefab, transform.position, transform.rotation);
                numPatty++;
            }
        }

	}
}
