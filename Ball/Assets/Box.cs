using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;
    /*public bool hasParticles;
    private ParticleSystem particle;*/

    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if(gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        //particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") && gameManager != null)
        {
            //gameManager.cratesCollected++;
            gameManager.CrateUpdate();
            /*if (hasParticles)
            {
                particle.Play();
            }*/
            Destroy(gameObject, 0);
        }
    }
}
