using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
//using UnityEngine.CoreModule;

public class GameManager : MonoBehaviour
{
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
        }
    }
    public Player[] players = new Player[2];
    public static GameManager instance;
    //public StateController[] controllers;
    public int playersInGame = 0;
    public bool gameStarted = false;
    public bool hitSlow = false;
    private int hitSlowFrames;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 2;
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        players[playersInGame] = new Player(playersInGame + 1, 100,playerInput.gameObject.GetComponent<StateController>());
        playerInput.transform.position = new Vector3((playersInGame - 1) * 5, 0, 0);
        playersInGame++;
    }
    public void Hit()
    {
        hitSlow = true;
        hitSlowFrames = 0;
    }
    void Update()
    {
        if(!gameStarted) { 
            if (playersInGame != 2)
            {
                Time.timeScale = 0f;
            }
            else
            {
                players[0].controller.opponent = players[1].obj;
                players[1].controller.opponent = players[0].obj;
                Time.timeScale = 1f;
                gameStarted = true;
            }
        }

        if(hitSlow)
        {
            Time.timeScale = 0.5f;
            hitSlowFrames++;
            if (hitSlowFrames > 3)
            {
                hitSlow = !hitSlow;
            }
        }
    }
}
