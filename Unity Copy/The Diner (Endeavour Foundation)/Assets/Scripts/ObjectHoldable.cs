using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectHoldable : MonoBehaviour {

    [HideInInspector]
    public Controller parent;

    public bool hold = true;
    public bool destroy = false;
    public bool dial = false;

    public GameObject startTriggerObj;
}
