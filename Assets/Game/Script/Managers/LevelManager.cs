using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int currentScene;
    private int sceneToContiniue;

    private void Update()
    {
        if (Input.anyKey)
        {
            text.GameObject().SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene( PlayerPrefs.GetInt("SavedScene"));
    }

    public void Exit()
    {
        Application.Quit(); 
    }
}