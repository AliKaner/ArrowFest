using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] private Animation anim;
  [SerializeField] private int gold;
  [SerializeField] private GameObject arrow;
  

  public void Death()
  {
    MoneyManager.Instance.goldPerLevel += gold;
    MoneyManager.Instance.GainPoint(gold);
    arrow.SetActive(true);
    anim.Play();
    
  }
}
