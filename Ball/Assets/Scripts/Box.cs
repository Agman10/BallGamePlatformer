using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;
    /*public bool hasParticles;
    private ParticleSystem particle;*/
    private Rigidbody rb;
    public GameObject model;
    public GameObject destructionEffect;


    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        rb = GetComponent<Rigidbody>();
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
            if(model != null && destructionEffect != null)
            {
                
                model.SetActive(false);
                destructionEffect.SetActive(true);
                rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                Destroy(gameObject, 0.2f);
            } else
            {
                Destroy(gameObject, 0);
            }
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion") && gameManager != null)
        {
            gameManager.CrateUpdate();
            if (model != null && destructionEffect != null)
            {

                model.SetActive(false);
                destructionEffect.SetActive(true);
                rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                Destroy(gameObject, 0.5f);
            }
            else
            {
                Destroy(gameObject, 0);
            }
        }
    }
}
