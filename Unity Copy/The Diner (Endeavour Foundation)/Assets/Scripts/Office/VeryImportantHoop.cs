using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VeryImportantHoop : MonoBehaviour {

    public GameObject hoopScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BasketBall")
        {
            hoopScore.GetComponent<TextMeshPro>().text = "Yay!";
        }
    }
}
