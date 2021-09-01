using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int coins;
    private Text coinText;
    public LifeManager lifeManager;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("CoinCount");
        coinText = GetComponent<Text>();
        coinText.text = "x " + coins.ToString();

    }

    public void AddCoins(int value)
    {
        coins += value;
        //PlayerPrefs.SetInt("CoinCount", coins);
        if(coins >= 100)
        {
            coins -= 100;
            lifeManager.ChangeLives(1);
        }
        PlayerPrefs.SetInt("CoinCount", coins);
        //coins = PlayerPrefs.GetInt("CoinCount");
        coinText.text = "x " + coins.ToString();
    }
}
