
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*Player class holds all the information necessary per player, id number, current HP, the gameobject and the controller script*/
    public class Player
    {
        public int id;
        public StateController controller;
        public int hp;
        public GameObject obj;
        public Player(int id, int hp, StateController controller)
        {
            this.id = id;
            this.controller = controller;
            this.hp = hp;
            this.obj = controller.gameObject;
            this.controller.id = id;
            Debug.Log("Created");
        }
    }
    public Player[] players = new Player[2];
    public static GameManager instance;
    public int minPlayers;
    public int playersInGame = 0;
    public bool gameStarted = false;
    public bool hitSlow = false;
    private int hitSlowFrames;
    public GameObject[] waitforPlayer;
    public bool gameWon = false;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 2;
    }
    /*MakeBot() will create a StateController with no link to an input system, which will do nothing*/
    public void makeBot(StateController sc)
    {
        players[1] = new Player(2, 100, sc);
    }
    /*OnPlayerJoined is called when a new controller presses a button, and will create a new player object, and change the ui to indicate that a player has joined.*/
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        players[playersInGame] = new Player(playersInGame + 1, 100, playerInput.gameObject.GetComponent<StateController>());
        playerInput.transform.position = new Vector3((playersInGame - 1) * 5, 0, 0);
        waitforPlayer[playersInGame].SetActive(false);
        playersInGame++;
    }
    /*Hit() will deal damage to the player associated with the given id number. It will then prompt the UI to update, and check if the player taking damage dies.*/
    public void Hit(int id, int damage)
    {
        players[Mathf.Abs(id - 1)].hp -= damage;
        if (players[Mathf.Abs(id - 1)].hp <= 0)
        {
            gameWon = true;
            UIManager.instance.WinGame(Mathf.Abs(id-2) + 1);
            Invoke("BacktoTitle", 5f);
        }
        hitSlow = true;
        hitSlowFrames = 0;
        UIManager.instance.UpdateHealthBar(Mathf.Abs(id - 1));
    }
    void Update()
    {
        if(!gameStarted) { 
            if (playersInGame != minPlayers)
            {

            }
            else
            {
                players[0].controller.opponent = players[1].obj;
                players[1].controller.opponent = players[0].obj;
                Time.timeScale = 1f;
                UIManager.instance.StopWaiting();
                gameStarted = true;
            }
        }

        if(hitSlow)
        {
            Time.timeScale = 0f;
            hitSlowFrames++;
            if (hitSlowFrames > 5)
            {
                hitSlow = !hitSlow;
                Time.timeScale = 1f;
            }
        }
    }
    /*Dummy Function that allows the invoking of changing scenes.*/
    void BacktoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
