using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   public static MoneyManager Instance;
   
   public TextMeshProUGUI text;
   public int goldPerLevel;

   private void Awake()
   {
      goldPerLevel = 0;
   }

   void IncreaseGoldPerLevel(int amount)
   {
      goldPerLevel += amount;
   }

   public void GainPoint(int point)
   {
      PlayerPrefs.SetInt("Point",PlayerPrefs.GetInt("Point")+point);
      RefreshText();
   }

   public void AddGain()
   {
      PlayerPrefs.SetInt("Point",PlayerPrefs.GetInt("Point")+goldPerLevel);
      RefreshText();
   }

   public void RefreshText()
   {
      text.text = PlayerPrefs.GetInt("Point").ToString();
   }
   
}
