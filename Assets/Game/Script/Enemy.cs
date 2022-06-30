using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public bool isDead = false;
  [SerializeField] private Animator anim;
  [SerializeField] private int gold;
  [SerializeField] private GameObject arrow;
  private static readonly int death = Animator.StringToHash("Death");

  private void Awake()
  {
    anim = GetComponent<Animator>();
  }

  public void Death()
  {
    isDead = true;
    MoneyManager.Instance.goldPerLevel += gold;
    MoneyManager.Instance.GainPoint(gold);
    arrow.SetActive(true);
    anim.SetBool(death,true);
  }
}
