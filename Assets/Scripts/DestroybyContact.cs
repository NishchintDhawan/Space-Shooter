using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int ScoreValue;
    private GameController gameController;

    private void Start()
    {
        //GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

/*
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController = null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    */
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GetComponent<GameController>().GameOver();
        }

        gameController.GetComponent<GameController>().AddScore(ScoreValue);  // To add score﻿ 
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
