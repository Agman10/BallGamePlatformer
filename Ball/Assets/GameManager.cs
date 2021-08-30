using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text crateText;
    public int cratesCollected;
    public int maxCrates;
    public int currentScene;
    //public Text coinText;

    public GameObject whiteGem;
    //public GameObject gemPos;
    public Player player;
    /*public GameObject statsObject;
    public Stats stats;*/
    public LifeManager lifeManager;

    public GameObject secretGem;
    public GameObject star;

    public bool collectedWhiteGem, collectedSecretGem, collectedStar;
    public int levelID;
    public string secretGemColor;

    public GameObject lifeIcon;
    public GameObject torus;
    public GameObject torusUI;
    public GameObject burntUI;
    public GameObject iceCube;
    public GameObject iceCubeUI;
    public GameObject tombStone;

    public bool angel;

    // Start is called before the first frame update
    void Start()
    {
        /*PlayerPrefs.DeleteKey("WhiteGem0");
        PlayerPrefs.DeleteKey("SecretGemGreen");*/
        if (crateText != null)
        {
            crateText.text = cratesCollected.ToString() + " / " + maxCrates.ToString();
        }
        if(whiteGem != null)
        {
            whiteGem.SetActive(false);
        }
        if(star != null && PlayerPrefs.GetInt("Star" + levelID.ToString()) == 1)
        {
            star.SetActive(false);
        }
        if(secretGem != null && PlayerPrefs.GetInt("SecretGem" + secretGemColor.ToString()) == 1)
        {
            secretGem.SetActive(false);
        }

    }

    void Update()
    {


        if (angel)
        {
            player.transform.position = player.transform.position + new Vector3(0, 1 * Time.deltaTime, 0);
        }
    }

    public void Die(int attributeID)
    {
        player.alive = false;
        StartCoroutine(Death(attributeID));
    }

    public IEnumerator Death(int id)
    {
        yield return StartCoroutine(LoseLife(id));
        yield return StartCoroutine(Restart());
    }

    IEnumerator LoseLife(int id)
    {
        lifeManager.ChangeLives(-1);

        if(id == 2)
        {
            player.rb.constraints = RigidbodyConstraints.FreezeAll;
            if (iceCube != null && iceCubeUI != null)
            {
                iceCube.SetActive(true);
                iceCubeUI.SetActive(true);
                lifeManager.FreezeLifeIcon();
            }
        }
        else if (id == 1 && lifeIcon != null && burntUI != null)
        {
            burntUI.SetActive(true);
            lifeIcon.SetActive(false);
            /*if (lifeIcon != null && burntUI != null)
            {
                burntUI.SetActive(true);
                lifeIcon.SetActive(false);
                //torusUI.SetActive(true);
            }*/
        }
        else if(id == 3)
        {
            player.rb.constraints = RigidbodyConstraints.FreezeAll;
            int randomDeathID = Random.Range(0, 2);
            //Debug.Log(randomDeathID);

            if(randomDeathID == 0)
            {
                player.transform.rotation = Quaternion.identity;
                player.sphereCollider.enabled = false;
                angel = true;
                if (torus != null && torusUI != null && lifeIcon != null)
                {
                    torus.SetActive(true);
                    torusUI.SetActive(true);
                    lifeManager.FreezeLifeIcon();
                    lifeIcon.transform.rotation = Quaternion.identity;
                }
            }
            else
            {
                if (tombStone != null && torusUI != null)
                {
                    torusUI.SetActive(true);
                    player.sphereCollider.enabled = false;
                    player.meshRenderer.enabled = false;
                    tombStone.transform.position = player.transform.position;
                    //tombStone.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
                    tombStone.SetActive(true);
                }
            }
        }
        else
        {
            if(torusUI != null)
            {
                torusUI.SetActive(true);
                /*lifeManager.FreezeLifeIcon();
                lifeIcon.transform.rotation = Quaternion.identity;*/
            }
            
        }
        yield return new WaitForSeconds(2);
    }

    IEnumerator Restart()
    {
        if (lifeManager.lives >= 0)
        {
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            PlayerPrefs.SetInt("CoinCount", 0);
            SceneManager.LoadScene(1);
        }
        yield return null;
    }

    public void CrateUpdate()
    {
        cratesCollected++;
        if (crateText != null)
        {
            crateText.text = cratesCollected.ToString() + " / " + maxCrates.ToString();
        }
        if (cratesCollected >= maxCrates && PlayerPrefs.GetInt("WhiteGem" + levelID.ToString()) != 1)
        {
            //Instantiate(gem, gemPos.transform.position, gem.transform.rotation);
            whiteGem.SetActive(true);
        }
    }

    public void GemCollected(bool secret)
    {
        if (!secret)
        {
            collectedWhiteGem = true;
        } else
        {
            collectedSecretGem = true;
        }
    }
}
