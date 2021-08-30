using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text coinText;
    public int coinsCollected;
    public Text livesText;
    public int livesAmount;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coinsCollected.ToString();
        livesText.text = "Lives: " + livesAmount.ToString();
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoinUpdate(int amount)
    {
        coinsCollected += amount;
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinsCollected.ToString();
        }
    }

    public void LivesUpdate(int amount)
    {
        livesAmount += amount;
        if(livesText != null)
        {
            livesText.text = "Lives: " + livesAmount.ToString();
        }
    }
}
