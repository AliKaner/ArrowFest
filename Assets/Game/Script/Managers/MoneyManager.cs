using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   public static MoneyManager Instance;
   public float Money;
   void Start()
   {
      if (PlayerPrefs.GetFloat("firstgame") == 0)
      {
         Money = PlayerPrefs.GetFloat("money", 0);
         PlayerPrefs.SetFloat("firstgame", 1);
      }
      else
      {
         Money = PlayerPrefs.GetFloat("money", 0);
      }
      Instance = this;
      moneyUI.RefreshText();
   }

   [SerializeField] private MoneyUI moneyUI;
   public int goldPerLevel;
   

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
