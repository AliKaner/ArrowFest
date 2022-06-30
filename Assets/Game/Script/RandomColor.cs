using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
   [SerializeField] private Material[] materials;
   [SerializeField] private GameObject[] Enemys;

   private void SetColor(GameObject[] objects)
   {
      int selecteColor = Random.Range(0, materials.Length);
      foreach (GameObject gameObject in Enemys)
      {
         gameObject.GetComponent<SkinnedMeshRenderer>().material = materials[selecteColor];
      }
   }
   private void Awake()
   {
     SetColor(Enemys);
   }
}
