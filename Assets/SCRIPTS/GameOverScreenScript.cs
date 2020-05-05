using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenScript : MonoBehaviour
{
    public Text gameOverText, scoreText, continueText;

    void Start()
    {
        gameOverText.text = "You Died!";
        //scoreText.text = "But hey, you nabbed" + FINALSCORE + "along the way";
    }


    void Update()
    {
        
    }
}
