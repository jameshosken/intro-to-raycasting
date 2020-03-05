using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SheepPlacementHandler : MonoBehaviour
{

    [SerializeField] GameObject sheepTemplate;

    //Since this script is not attached to the camera we must store a reference to it:
    Camera cam;

    void Start()
    {
        //Find and store the main camera in the scene
        cam = Camera.main;
    }

    void Update()
    {
        //Only raycast if mouse has been clicked
        if (Input.GetMouseButtonDown(0))
        {
            HandleRaycastPlacement();
        }
    }

    void HandleRaycastPlacement()
    {
        //Create a ray pointing out from the camera into the scene
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f)){

            //Set the position of out new sheep based on the point we hit:
            Vector3 position = hit.point;

            GameObject sheepClone = Instantiate(sheepTemplate, position, Quaternion.identity);

            //Set the 'up' vector of the sheep based on the Normal of the surface we hit. 
            //This will place the sheep standing 'up' on the surface
            sheepClone.transform.up = hit.normal;

            //This isn't necessary but helps keep our hierarchy clean, by childing the sheep to this SheepPlacementHandler object
            sheepClone.transform.parent = transform;
        }
    }
}
