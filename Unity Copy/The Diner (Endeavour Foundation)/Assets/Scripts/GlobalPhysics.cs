using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPhysics : MonoBehaviour {

    bool mousestate = true;
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        mousestate = true;
    }

    void OnMouseDrag()
    {
        if (mousestate == true)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        mousestate = false;
    }
}
