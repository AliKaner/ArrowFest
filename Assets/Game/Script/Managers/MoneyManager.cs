using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   private static MoneyManager _instance = null;

   public static MoneyManager Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = new GameObject("MoneyManager").AddComponent<MoneyManager>();
         }

         return _instance;
      }
   }
   

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
