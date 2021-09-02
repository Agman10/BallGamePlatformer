using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    public GameObject[] skins;
    public int skinAmount;
    // Start is called before the first frame update
    void Start()
    {
        skins[0].SetActive(false);
        skins[PlayerPrefs.GetInt("SkinSelected")].SetActive(true);
    }
}
