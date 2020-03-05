using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSelectionHandler : MonoBehaviour
{
    //Keep track of selected object
    GameObject selection = null;

    // Update is called once per frame
    void Update()
    {
        //When mouse is right clicked:
        if (Input.GetMouseButtonDown(1))
        {
            HandleRaycastSelection();
        }
    }

    private void HandleRaycastSelection()
    {
        //Cast ray from screen to world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //We can actually declare 'hit' as a type RaycastHit inline:
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            //Reference the object that we hit
            GameObject hitObject = hit.collider.gameObject;


            if (hitObject.GetComponentInParent<Rigidbody>() != null)
            {
                ClearSelection();
                selection = hitObject.GetComponentInParent<Rigidbody>().gameObject;
                SetColourOfChildren(selection, Color.red);
            }
            else
            {
                ClearSelection();
            }
        }
        else
        {
            ClearSelection();
        }
    }

    private void ClearSelection()
    {
        if (selection != null)
        {
            SetColourOfChildren(selection, Color.white);
            selection = null;
        }
    }

    void SetColourOfChildren(GameObject obj, Color col)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        for(int i = 0; i < renderers.Length; i++)
        {
            Material mat = renderers[i].material;
            mat.color = col;
        }
    }


}
