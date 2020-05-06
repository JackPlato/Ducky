using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    public Text gameOverText, scoreText, continueText;

    void Start()
    {
        gameOverText.text = "You Died!";
        //scoreText.text = "But hey, you nabbed" + FINALSCORE + "\nalong the way";
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 0);
        continueText.color = new Color(continueText.color.r, continueText.color.g, continueText.color.b, 0);
        StartCoroutine(TextCoroutine());
    }


    void Update()
    {
        if (continueText.color.a > 0 && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }

    IEnumerator TextCoroutine()
    {
        yield return new WaitForSeconds(1);
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 255);
        yield return new WaitForSeconds(1);
        continueText.color = new Color(continueText.color.r, continueText.color.g, continueText.color.b, 255);

    }
}
