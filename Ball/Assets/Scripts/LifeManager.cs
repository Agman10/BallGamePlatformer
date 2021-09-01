using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int lives;
    private Text livesText;
    public CollectableSpin lifeIcon;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        lives = PlayerPrefs.GetInt("PlayerLives");
        //livesText = GetComponent<Text>();
        livesText.text = "x " + lives.ToString();
        
    }

    public void ChangeLives(int value)
    {
        lives += value;
        PlayerPrefs.SetInt("PlayerLives", lives);
        //coins = PlayerPrefs.GetInt("CoinCount");
        livesText.text = "x " + lives.ToString();
    }

    public void FreezeLifeIcon()
    {
        lifeIcon.spinSpeed = 0;
        lifeIcon.xSpeed = 0;
        lifeIcon.zSpeed = 0;
    }
}
