using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button startButton, creditsButton, quitButton;
    public GameObject titleScreen, creditsScreen, gameOverScreen;
    public Animator startAnim;
    private bool credits = false;

    void Start()
    {
        titleScreen.SetActive(true);
        creditsScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        startButton.onClick.AddListener(StartGame);
        creditsButton.onClick.AddListener(Credits);
        quitButton.onClick.AddListener(Quit);
    }

    void Update()
    {
        if (credits && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Cancel")))
        {
            Credits();
        }
    }

    void StartGame()
    {
        startAnim.SetTrigger("Start");
        titleScreen.SetActive(false);
    }
    
    void Credits()
    {
        credits = !credits;
        if (credits)
        {
            titleScreen.SetActive(false);
            creditsScreen.SetActive(true);
        }
        if (!credits)
        {
            titleScreen.SetActive(true);
            creditsScreen.SetActive(false);
        }
    }

    void Quit()
    {
        Application.Quit();
    }
}
