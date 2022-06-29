using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   public static MoneyManager Instance;

   [SerializeField] private MoneyUI moneyUI;
   public int goldPerLevel;

   private void Awake()
   {
      goldPerLevel = 0;
      moneyUI.RefreshText();
   }

   void IncreaseGoldPerLevel(int amount)
   {
      goldPerLevel += amount;
   }

   public void GainPoint(int point)
   {
      PlayerPrefs.SetInt("Point",PlayerPrefs.GetInt("Point")+point);
      moneyUI.RefreshText();
   }

   public void AddGain()
   {
      PlayerPrefs.SetInt("Point",PlayerPrefs.GetInt("Point")+goldPerLevel);
      moneyUI.RefreshText();
   }
}
