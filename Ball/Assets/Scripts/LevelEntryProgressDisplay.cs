using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryProgressDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject star;
    public GameObject starCollected;
    public GameObject whiteGem;
    public GameObject whiteGemCollected;
    public GameObject secretGem;
    public GameObject secretGemCollected;
    public int levelID;
    public string secretGemColor;

    public bool unlockableStage;
    public int starsRequired;
    public int whiteGemsRequired;
    public GameObject portalDisabled;
    public GameObject portalEnabled;
    void Start()
    {
        if(star != null && starCollected != null && PlayerPrefs.GetInt("Star" + levelID.ToString()) == 1)
        {
            star.SetActive(false);
            starCollected.SetActive(true);
        }
        if(whiteGem != null && whiteGemCollected != null && PlayerPrefs.GetInt("WhiteGem" + levelID.ToString()) == 1)
        {
            whiteGem.SetActive(false);
            whiteGemCollected.SetActive(true);
        }

        if (secretGem != null && secretGemCollected && PlayerPrefs.GetInt("SecretGem" + secretGemColor.ToString()) == 1)
        {
            secretGem.SetActive(false);
            secretGemCollected.SetActive(true);
        }

        if(unlockableStage && portalEnabled != null && PlayerPrefs.GetInt("StarsCollected") >= starsRequired && PlayerPrefs.GetInt("WhiteGemsCollected") >= whiteGemsRequired)
        {
            portalEnabled.SetActive(true);
            if (portalDisabled != null)
            {
                portalDisabled.SetActive(false);
            }
            
            
        }
    }
}
