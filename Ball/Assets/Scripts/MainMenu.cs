using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private int lives;
    public int startingLives;
    private int levelAmount = 5;

    public int skinSelected;
    public PlayerSkin playerSkins;
    void Start()
    {
        skinSelected = PlayerPrefs.GetInt("SkinSelected");
        lives = PlayerPrefs.GetInt("PlayerLives");
    }

    public void StartGame()
    {
        if (lives < startingLives)
        {
            PlayerPrefs.SetInt("PlayerLives", startingLives);
        }
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerLives", startingLives);
        skinSelected = 0;
        foreach (GameObject skinSelected in playerSkins.skins)
        {
            skinSelected.SetActive(false);
        }
        playerSkins.skins[PlayerPrefs.GetInt("SkinSelected")].SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void changeSkin(bool leftDirection)
    {
        foreach(GameObject skinSelected in playerSkins.skins)
        {
            skinSelected.SetActive(false);
        }
        if (leftDirection)
        {
            if (skinSelected <= 0)
            {
                skinSelected = playerSkins.skinAmount;
            }
            else
            {
                skinSelected -= 1;
            }
        }
        else
        {
            if (skinSelected >= playerSkins.skinAmount)
            {
                skinSelected = 0;
            }
            else
            {
                skinSelected++;
            }
        }
        
        PlayerPrefs.SetInt("SkinSelected", skinSelected);
        playerSkins.skins[skinSelected].SetActive(true);
    }


    public void UnlockEverything()
    {
        PlayerPrefs.SetInt("PlayerLives", 99);
        PlayerPrefs.SetInt("CoinCount", 99);
        for (int i = 0; i < levelAmount; i++)
        {
            PlayerPrefs.SetInt("Star" + i.ToString(), 1);
            PlayerPrefs.SetInt("StarsCollected", levelAmount);
            PlayerPrefs.SetInt("WhiteGem" + i.ToString(), 1);
            PlayerPrefs.SetInt("WhiteGemsCollected", levelAmount);
        }
        
        PlayerPrefs.SetInt("SecretGemRed", 1);
        PlayerPrefs.SetInt("SecretGemGreen", 1);
        PlayerPrefs.SetInt("SecretGemBlue", 1);
        PlayerPrefs.SetInt("SecretGemPurple", 1);
        PlayerPrefs.SetInt("SecretGemYellow", 1);
    }
}
