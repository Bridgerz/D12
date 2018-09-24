using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPhysics : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public float vertOffset;

    private void Start()
    {
        transform.GetComponent<Rigidbody>().freezeRotation = true;
        transform.GetComponent<Rigidbody>().useGravity = true;
    }

    void OnMouseDown()
    {
        vertOffset = transform.position.y;
        transform.GetComponent<Rigidbody>().useGravity = false;
        transform.GetComponent<Rigidbody>().mass = 1000;
    }

    void OnMouseDrag()
    {
        Plane plane = new Plane(Vector3.up, new Vector3(0, 2.75f, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            transform.position = Vector3.SmoothDamp(transform.position, ray.GetPoint(distance), ref velocity, .05f);
        }
    }

    private void OnMouseUp()
    {
        transform.GetComponent<Rigidbody>().useGravity = true;
        transform.GetComponent<Rigidbody>().mass = 1;
        Physics.gravity = new Vector3(0, -75.0f, 0);
        vertOffset = 0;
    }

}