using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelUnLock = 1;
    public Button[] buttons;
    

    void Start()
    {
        levelUnLock = PlayerPrefs.GetInt("level", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i <levelUnLock; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        int currLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("level", currLevel + 1); 
    }
    public void ExitGame()
    {
      Application.Quit();
    }
}
