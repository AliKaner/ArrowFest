using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManagment : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    public LayerMask layerMask;
    public float minX, maxX;
    public float distance;
    private Queue<GameObject> _arrowPool = new Queue<GameObject>();
    public int arrowCount;
    
    [SerializeField] private GameObject arrow;
    
    private int _maxArrow;

    void FillPool(int amount, GameObject arrow)
    {
        Transform parent = transform;

        for (int i = 0; i < amount; i++)
        {
            //GameObject instantiate = Instantiate(arrow, parent.position, parent.rotation, parent);
            _arrowPool.Enqueue(Instantiate(arrow, parent.position, parent.rotation, parent));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Door":
                
                DoorEffect doorEffect = other.gameObject.GetComponent<DoorEffect>();
                var effectType = doorEffect.selectedEffect;
                var effectAmount = doorEffect.effectAmount;
                
                switch (effectType)
                {
                    case DoorEffect.Effect.Addition:
                        AddArrow(effectAmount);
                        break;
                    case DoorEffect.Effect.Extraction:
                        RemoveArrow(effectAmount);
                        break;
                    case DoorEffect.Effect.Division:
                        RemoveArrow(arrowCount-(arrowCount/effectAmount));
                        break;
                    case DoorEffect.Effect.Multiplication:
                        AddArrow(arrowCount*(effectAmount-1));
                        break;
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
        // ReSharper disable once PossibleLossOfFraction
        float angle = 360 / arrowCount;

        for (int i = 0; i < arrowCount; i++)
        {
            MoveObjects(arrows[i].transform, i * angle);
        }
    }
    public void RemoveArrow(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            arrowCount--;
            GameObject arrow = arrows[arrowCount];
            arrows.RemoveAt(arrowCount);
            _arrowPool.Enqueue(arrow);
            arrow.transform.parent = null;
        }
        Sort();
    }
    public void AddArrow(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            arrowCount++;
            GameObject arrow = _arrowPool.Dequeue();
            arrow.transform.parent = gameObject.transform;
            arrows.Add(arrow);
            arrow.transform.localPosition = Vector3.zero;
        }
        Sort();
    }
    void GetRay()
    {
        Vector3 mousePos = Input.mousePosition;
        if (Camera.main != null)
        {
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
    }

    private void Awake()
    {
        FillPool(400,arrow);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GetRay();
        }
    }
}

