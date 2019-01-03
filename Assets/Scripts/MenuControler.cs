using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour {

    public Text HighScoreTxt;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Point"))
            {
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Point"));
            }
        }
        HighScoreTxt.text = PlayerPrefs.GetInt("HighScore").ToString();

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetHighScore()
    {
        HighScoreTxt.text = "0";
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
