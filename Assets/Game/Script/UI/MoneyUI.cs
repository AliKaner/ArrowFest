using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Image coinImage;
    [SerializeField] private TextMeshProUGUI text;
    
    public void RefreshText()
    {
        text.text = PlayerPrefs.GetInt("Point").ToString();
        
    }
}
