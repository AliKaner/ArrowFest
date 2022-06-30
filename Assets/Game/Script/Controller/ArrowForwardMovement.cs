using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForwardMovement : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private Vector3 moveVector;

   private void Update()
   {
      transform.Translate(moveVector*speed*Time.deltaTime);
   }
}
