using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject singlemultiScreen;
    public Animator[] anim;
    private int index = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            titleScreen.SetActive(true);
            optionsScreen.SetActive(false);
            creditsScreen.SetActive(false);
            singlemultiScreen.SetActive(false);
            index = 0;
        }
    }

    public void StartButton()
    {
        this.transform.GetChild(index).gameObject.GetComponent<ButtonActive>().nextScreen = singlemultiScreen;
        anim[index].SetTrigger("StartButton");
        index = 3;
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
        anim[3].SetTrigger("SPB");
    }
    public void MultiplayerButton()
    {
        anim[3].SetTrigger("MPB");
    }
}
