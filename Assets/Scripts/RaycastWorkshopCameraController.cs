using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWorkshopCameraController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float moveSpeed = 0.1f;
    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horz * rotationSpeed, Space.World);
        transform.Translate(Vector3.forward * vert * moveSpeed, Space.Self);
    }
}
