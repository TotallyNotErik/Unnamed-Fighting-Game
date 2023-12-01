using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public Animator WaitingScreen;
    public static UIManager instance;
    public GameObject[] healthbars;
    public GameObject WinScreen;
    void Awake()
    {
        instance = this;
    }
    public void StopWaiting()
    {
        WaitingScreen.SetTrigger("DoneWaiting");
    }
    // Update is called once per frame

    public void UpdateHealthBar(int playerId)
    {
        healthbars[playerId].transform.GetChild(0).GetComponent<Image>().fillAmount = (float)GameManager.instance.players[playerId].hp / 100f;
    }
    public void WinGame(int id)
    {
        WinScreen.SetActive(true);
        WinScreen.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Player " + id + " wins!";
    }
    void Update()
    {
        foreach (GameObject hp in healthbars)
        {
            if (hp.GetComponent<Image>().fillAmount > hp.transform.GetChild(0).GetComponent<Image>().fillAmount)
            {
                hp.GetComponent<Image>().fillAmount -= 1f / 500f;
            }
        }
    }
    
}
