using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private int lives;
    public int startingLives;
    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("PlayerLives");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if(lives < startingLives)
        {
            PlayerPrefs.SetInt("PlayerLives", startingLives);
        }
        
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerLives", startingLives);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
