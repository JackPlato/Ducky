using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public Text scoreText;
    public GameObject victoryScreen;
    public bool triggered = false;
    void OnTriggerEnter(Collider other)
    {
        triggered = true;
        victoryScreen.SetActive(true);
        //scoreText.text = "And you got $" + FINALSCORE + " too!";
    }

    private void Update()
    {
        if(triggered && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene_Bel", LoadSceneMode.Single);
        }
    }
}
