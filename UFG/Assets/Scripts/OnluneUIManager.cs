using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class OnluneUIManager : MonoBehaviourPunCallbacks
{
    public Animator WaitingScreen;
    public static OnluneUIManager instance;
    public GameObject[] healthbars;
    public GameObject WinScreen;
    void Awake()
    {
        instance = this;
    }
    /*Starts the game and removes the waiting screen*/
    [PunRPC]
    public void StopWaiting()
    {
        WaitingScreen.SetTrigger("DoneWaiting");
    }
    /*Updates the UI health bar*/
    [PunRPC]
    public void UpdateHealthBar(int playerId)
    {
        healthbars[playerId].transform.GetChild(0).GetComponent<Image>().fillAmount = (float)GameNetworkController.instance.players[playerId].hp / 100f;
    }
    /*Sets the winscreen active and changes the text to the player id number*/
    [PunRPC]
    public void WinGame(int id)
    {
        WinScreen.SetActive(true);
        WinScreen.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[id-1].NickName + " wins!";
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
