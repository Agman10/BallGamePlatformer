using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    //private Player player;
    private GameObject gameManagerObject;
    private GameManager gameManager;

    public int attributeID;
    //0 is for falling in bottomless pits or poison water
    //1 is for lava attribute
    //2 is for ice attribute


    //public LifeManager lifeManager;
    // Start is called before the first frame update

    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        //gameManager = gameManagerObject.GetComponent<GameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager != null && gameManager.player.alive)
        {
            //lifeManager.ChangeLives(-1);
            //gameManager.player.alive = false;
            gameManager.Die(attributeID);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameManager.player.Knockback(new Vector3(1, 1, 1), 20005);
        }
    }*/
}
