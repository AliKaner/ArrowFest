using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
   public bool isStarted;
   [SerializeField] private float speed;
   
   void Movement(float _speed)
   {
      transform.position += Vector3.forward * Time.deltaTime * _speed ;
   }
   private void Update()
   {
    Movement(speed);  
   }
}
