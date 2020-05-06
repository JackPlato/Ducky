using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public Text scoreText;
    public GameObject victoryScreen;
    void OnTriggerEnter(Collider other)
    {
        victoryScreen.SetActive(true);
        //scoreText.text = "And you got $" + FINALSCORE + " too!";
    }

    private void Update()
    {
        if(victoryScreen && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene_Bel", LoadSceneMode.Single);
        }
    }
}
