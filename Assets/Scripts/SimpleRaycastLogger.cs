using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This component shoots a ray from the gameObject and debugs info about the hit;

public class SimpleRaycastLogger : MonoBehaviour
{

    void Update()
    {
        //Create a ray from this object's position along its forward (z) axis:
        Ray ray = new Ray(transform.position, transform.forward);

        //Create an empty hit object to populate with our raycast data upon successful hit:
        RaycastHit hit;

        //Set a maximum distance for ray to travel:
        float maxDistance = 100f;

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            //Access the object we hit by calling hit.collider.gameObject:
            string hitName = hit.collider.gameObject.name;

            Debug.Log("Successful hit: " + hitName);

            //Draw a green line from position to hit point:
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
        else
        {
            Debug.Log("No hit");

            //Draw a red line from position to end of ray:
            Debug.DrawLine(ray.origin, ray.direction * maxDistance, Color.red);
        }
    }
}
