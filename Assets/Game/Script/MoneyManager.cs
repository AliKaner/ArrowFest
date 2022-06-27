using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   public static MoneyManager Instance;
   
   public TextMeshProUGUI text;
   

   public void GainPoint(int point)
   {
      PlayerPrefs.SetInt("Point",PlayerPrefs.GetInt("Point")+point);
      RefreshText();
   }

   public void RefreshText()
   {
      text.text = PlayerPrefs.GetInt("Point").ToString();
   }
   
}
