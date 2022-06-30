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

    private void Start()
    {
        Time.timeScale= 0;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            text.GameObject().SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void LoadMenu()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SaveScene",currentScene);
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SaveScene",1);
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        sceneToContiniue = PlayerPrefs.GetInt("SaveScene");
        if (sceneToContiniue != 0)
            SceneManager.LoadScene(sceneToContiniue);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("SaveScene",PlayerPrefs.GetInt("SaveScene")+1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("SaveScene"));
    }

    public void Exit()
    {
        Application.Quit(); 
    }
}