using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
            if (gameManager.collectedStar == true)
            {
                PlayerPrefs.SetInt("Star" + gameManager.levelID.ToString(), 1);

            }
            if (gameManager.collectedWhiteGem == true)
            {
                PlayerPrefs.SetInt("WhiteGem" + gameManager.levelID.ToString(), 1);
                //Debug.Log(PlayerPrefs.GetKey("WhiteGem0"));
                
            }
            if(gameManager.collectedSecretGem == true)
            {
                PlayerPrefs.SetInt("SecretGem" + gameManager.secretGemColor.ToString(), 1);
                //UnityEngine.Debug.Log("secret gem collected");
            }

        }
    }
}
