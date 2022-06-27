using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManagment : MonoBehaviour
{
    public float minX, maxX;
    public LayerMask layerMask;
    public float distance;

    void GetRay()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Pysics.Raycast(ray, out hit, 100, layerMask))
        {
            Vector3 mouse = hit.point;
            mouse.x = Math.Clamp(mouse.x, minX, maxX);
            distance = mouse.x;
        }

    }


}
