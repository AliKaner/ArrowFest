using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowManagment : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    public LayerMask layerMask;
    public float minX, maxX;
    public float distance;
    
    private Queue<GameObject> _arrowPool;
    [Range(0, 400)] public int arrowCount;
    
    private int _maxArrow;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Door":
                if (other.gameObject.isRed == true)
                {
                    TODO
                }
                break;
            case "Enemy":
                break;
        }
    }

    void MoveObjects(Transform objectTransform, float degree)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Cos(degree * Mathf.Deg2Rad);
        pos.y = Mathf.Sin(degree * Mathf.Deg2Rad);
        objectTransform.localPosition = pos * distance;
    }
    void Sort()
    {
        float angle = 1f;
        float arrowCount = arrows.Count;
        angle = 360 / arrowCount;

        for (int i = 0; i < arrowCount; i++)
        {
            MoveObjects(arrows[i].transform, i * angle);
        }
    }
    public void RemoveArrow(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            arrowCount -= amount;
            GameObject arrow = arrows[arrows.Count - 1];
            arrows.RemoveAt(arrows.Count - 1);
            _arrowPool.Enqueue(arrow);
        }
        Sort();
    }
    public void AddArrow(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            arrowCount += amount;
            GameObject arrow = _arrowPool.Dequeue();
            arrows.Add(arrow);
            arrow.transform.localPosition = Vector3.zero;
        }
        Sort();
    }
    void GetRay()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            Vector3 mouse = hit.point;
            mouse.x = Math.Clamp(mouse.x, minX, maxX);
            distance = mouse.x;
            Sort();
        }
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GetRay();
        }
    }
}

