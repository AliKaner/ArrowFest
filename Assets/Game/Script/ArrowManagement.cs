using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowManagement : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private int poolSize;
    
    private readonly Queue<GameObject> _arrowPool = new Queue<GameObject>();
    private int _maxArrow;
    private float _distanceHolder;
    
    public List<GameObject> arrows = new List<GameObject>();
    public float distance;
    public float rollDistance;
    public int degreeMultiplier;
    private float _expansionMultiplier = 1;
    public int arrowCount;
    
    private void FillPool(int amount, GameObject arrow)
    {
        Transform parent = transform;
        for (int i = 0; i < amount; i++)
        {
            _arrowPool.Enqueue(Instantiate(arrow, parent.position, parent.rotation, parent));
        }
    }

    private void Finish()
    {
        _expansionMultiplier = 5;
        Sort();
    }

    private void RemoveArrow(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            arrowCount--;
            GameObject arrow = arrows[arrowCount];
            arrows.RemoveAt(arrowCount);
            arrow.SetActive(false);
            _arrowPool.Enqueue(arrow);
            arrow.transform.parent = null;
        }
        Sort();
    }
    private void AddArrow(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            arrowCount++;
            GameObject arrow = _arrowPool.Dequeue();
            arrow.SetActive(true);
            arrow.transform.parent = gameObject.transform;
            arrows.Add(arrow);
            arrow.transform.localPosition = Vector3.zero;
        }
        Sort();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Door":
                var doorEffect = other.gameObject.GetComponent<DoorEffect>();
                var effectType = doorEffect.selectedEffect;
                var effectAmount = doorEffect.effectAmount;
                
                Debug.Log(effectAmount + " " + effectType);
                if(doorEffect.isUsed == false)
                {
                    switch (effectType)
                    {
                        case DoorEffect.Effect.Addition:
                            AddArrow(effectAmount);
                            break;
                        case DoorEffect.Effect.Extraction:
                            RemoveArrow(effectAmount);
                            break;
                        case DoorEffect.Effect.Division:
                            RemoveArrow(arrowCount-Mathf.FloorToInt(arrowCount/effectAmount));
                            break;
                        case DoorEffect.Effect.Multiplication:
                            AddArrow(arrowCount*(effectAmount-1));
                            break;
                    }
                }
                doorEffect.isUsed = true;
                break;
            case "Enemy":
                if (other.GetComponent<Enemy>().isDead == false)
                {
                    other.GetComponent<Enemy>().Death();
                    RemoveArrow(1);
                }
                break;
            case "Finish":
                Finish();
                break;
        }
    }

    void MoveObjects(Transform objectTransform, float degree)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Cos(degree * Mathf.Deg2Rad)*_expansionMultiplier;
        pos.y = Mathf.Sin(degree * Mathf.Deg2Rad);
        pos = pos * distance;
        //objectTransform.localPosition = Vector3.Lerp(objectTransform.localPosition,pos,0.4f);  TODO: belki lerp eklersem daha canlı durur
        objectTransform.localPosition = pos;
        distance += rollDistance;

    }
    void Sort()
    {
        distance = _distanceHolder;
        float angle = 360 / arrowCount*degreeMultiplier;

        for (int i = 0; i < arrowCount; i++)
        {
            MoveObjects(arrows[i].transform, i * angle);
        }
    }
    private void Awake()
    {
        FillPool(poolSize,arrow);
        _distanceHolder = distance;
    } 
}

