using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject singlemultiScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            titleScreen.SetActive(true);
            optionsScreen.SetActive(false);
            creditsScreen.SetActive(false);
            singlemultiScreen.SetActive(false);
        }
    }

    public void StartButton()
    {
        titleScreen.SetActive(false);
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        singlemultiScreen.SetActive(true);
    }
    public void OptionsButton()
    {
        titleScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void CreditsButton()
    {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void SinglePlayerButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
