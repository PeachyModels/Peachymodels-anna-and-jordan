using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Hand : MonoBehaviour {

    GameObject ObjectHoldable;
    public Controller controller;

    Rigidbody simulator;

	// Use this for initialization
	void Start () {

        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;
        controller = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {

        if (ObjectHoldable)
        {
            simulator.velocity = (transform.position - simulator.position) * 50f;
            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
            {
                ObjectHoldable.transform.parent = null;

                if (ObjectHoldable.GetComponent<ObjectHoldable>().hold == true)
                {
                    ObjectHoldable.GetComponent<Rigidbody>().isKinematic = false;
                    ObjectHoldable.GetComponent<Rigidbody>().velocity = simulator.velocity;
                }
                
                ObjectHoldable.GetComponent<ObjectHoldable>().parent = null;
                ObjectHoldable = null;
            }
        }

        else
        {
            if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

                foreach (Collider col in cols)
                {
                    if (ObjectHoldable == null && col.GetComponent<ObjectHoldable>() && col.GetComponent<ObjectHoldable>().parent == null)
                    {
                        if (col.GetComponent<ObjectHoldable>().hold == true)
                        {
                            ObjectHoldable = col.gameObject;
                            ObjectHoldable.transform.parent = transform;
                            ObjectHoldable.transform.localPosition = Vector3.zero;
                            ObjectHoldable.transform.localRotation = Quaternion.identity;
                            ObjectHoldable.GetComponent<Rigidbody>().isKinematic = true;
                            ObjectHoldable.GetComponent<ObjectHoldable>().parent = controller;
                        }
                        else if (col.GetComponent<ObjectHoldable>().destroy == true)
                        {
                            //not final
                            col.gameObject.GetComponent<ObjectHoldable>().startTriggerObj.GetComponent<GrillInput>().pattyStart = true;
                            //not final

                            Destroy(col.gameObject);
                            
                        }
                        else if (col.GetComponent<ObjectHoldable>().dial == true)
                        {
                            ObjectHoldable = col.gameObject;
                            ObjectHoldable.transform.localRotation = Quaternion.identity;
                        }
                        
                    }
                }
            }
        }
		
	}
}
