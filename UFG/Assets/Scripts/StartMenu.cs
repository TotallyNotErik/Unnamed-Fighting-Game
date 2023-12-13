using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class StartMenu : MonoBehaviourPunCallbacks, ILobbyCallbacks
{

    public GameObject titleScreen;
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject singlemultiScreen;
    public Animator[] anim;
    public int index = 0;
    public GameObject[] screens;
    public static StartMenu instance;

    public Button findRoomButton;
    public Button startGameButton;
    private List<GameObject> roomButtons = new List<GameObject>();
    private List<RoomInfo> roomList = new List<RoomInfo>();
    public RectTransform roomListContainer;
    public GameObject roomButtonPrefab;
    public GameObject[] playerContainers;
    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (index <= 3)
            {
                index = 0;
            }
            else if(index == 8)
            {
                index = 6;
                PhotonNetwork.LeaveRoom();
            }
            else
                index -= 1;
            SetScreen(index);
        }
        
    }
    public void SetScreen(int screen)
    {
        for (int j = 0; j < screens.Length; j++)
        {
            if (j == screen) { screens[screen].SetActive(true); }
            else
            {
                screens[j].SetActive(false);
            }
        }
    }

    public void StartButton()
    {
        this.transform.GetChild(index).gameObject.GetComponent<ButtonActive>().nextScreen = singlemultiScreen;
        anim[index].SetTrigger("StartButton");
        index = 2;
    }
    public void OptionsButton()
    {
        titleScreen.SetActive(false);
        optionsScreen.SetActive(true);
        index = 1;
    }

    public void CreditsButton()
    {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
        index = 2;
    }

    public void SinglePlayerButton()
    {
        anim[3].SetTrigger("SPB");
    }
    public void MultiplayerButton()
    {
        anim[3].SetTrigger("MPB");
    }
    public void LocalButton()
    {
        anim[4].SetTrigger("LB");
    }
    public void OnlineButton()
    {
        anim[4].SetTrigger("OB");
    }



    public void OnFindRoomButton()
    {
        index = 7;
        SetScreen(index);
    }


    public void OnCreateButton(TMP_InputField roomNameInput)
    {
        NetworkManager.instance.CreateRoom(roomNameInput.text);
    }

    public override void OnJoinedRoom()
    {
        index = 8;
        SetScreen(8);
        photonView.RPC("UpdateLobbyUI", RpcTarget.All);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateLobbyUI();
    }

    [PunRPC]
    void UpdateLobbyUI()
    {

        startGameButton.interactable = PhotonNetwork.IsMasterClient && PhotonNetwork.PlayerList.Length == 2;


        for(int k = 1; k >= PhotonNetwork.PlayerList.Length; k--)
        {
            playerContainers[k].gameObject.SetActive(false);
        }

        int j = 0;
        foreach (Player player in PhotonNetwork.PlayerList) 
        {
            playerContainers[j].gameObject.SetActive(true);
            playerContainers[j].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = player.NickName;
            j++;
        }



    }

    public void OnStartGameButton()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;

        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "Game");
    }




    GameObject CreateRoomButton()
    {
        GameObject buttonObj = Instantiate(roomButtonPrefab, roomListContainer.transform);
        roomButtons.Add(buttonObj);

        return buttonObj;
    }

    void UpdateLobbyBrowserUI()
    {
        Debug.Log(roomList.Count);

        foreach (GameObject button in roomButtons)
            button.SetActive(false);


        for (int x = 0; x < roomList.Count; ++x)
        {


            GameObject button = x >= roomButtons.Count ? CreateRoomButton() : roomButtons[x];

            button.SetActive(true);

            button.transform.Find("RoomNameText").GetComponent<TextMeshProUGUI>().text = roomList[x].Name;
            button.transform.Find("PlayerCountText").GetComponent<TextMeshProUGUI>().text = roomList[x].PlayerCount + "/ " + roomList[x].MaxPlayers;


            Button buttonComp = button.GetComponent<Button>();

            string roomName = roomList[x].Name;

            buttonComp.onClick.RemoveAllListeners();
            buttonComp.onClick.AddListener(() => { OnJoinRoomButton(roomName); });
        }
    }

    public void OnJoinRoomButton(string roomName)
    {
        NetworkManager.instance.JoinRoom(roomName);
    }

    public void OnRefreshButton()
    {
        UpdateLobbyBrowserUI();
    }

    public override void OnRoomListUpdate(List<RoomInfo> allRooms)
    {
        roomList = allRooms;
    }
}
