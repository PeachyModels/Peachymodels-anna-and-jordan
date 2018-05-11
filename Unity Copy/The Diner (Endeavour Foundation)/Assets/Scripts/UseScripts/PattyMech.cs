using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PattyMech : MonoBehaviour {

    bool grill = false;
    public float timer = 30;
    public GameObject patty;
    public float elapse = 0;
    public float duration;

    private float timerTrue;


    Color one = new Color32(225, 93, 93, 255);
    Color two = new Color32(124, 97, 67, 255);
    Color three = new Color32(66, 66, 66, 255);

    // Use this for initialization
    void Start () {

        timerTrue = timer;
        duration = timer / 2;

    }
	
	// Update is called once per frame
	void Update () {
        if (grill == true)
        {
            timer -= Time.deltaTime;

            if (timer < timerTrue)
            {
                patty.GetComponent<Renderer>().material.color = Color.Lerp(one, two, elapse);

            }

            if (timer <= (timerTrue / 2))
            {
                if (timer > 0)
                {
                    if (elapse >= 1)
                    {
                        elapse = 0;
                    }

                    tag = "PattyCooked";
                    patty.GetComponent<Renderer>().material.color = Color.Lerp(two, three, elapse);
                }
                else
                {
                    patty.GetComponent<Renderer>().material.color = three;
                }
                     
            }

            if (timer < (timerTrue / 6))
            {
                tag = "Patty";
            }

            if (elapse < 1)
            {
                elapse += Time.deltaTime / duration;
            }

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GrillTop")
        {
            grill = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GrillTop")
        {
            grill = false;
        }
    }
}
