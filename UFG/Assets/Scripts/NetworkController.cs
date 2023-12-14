using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.InputSystem;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public PlayerInput inputs;
    public Player photonPlayer;
    public OnlineStateController OSController;

    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;

        GameNetworkController.instance.players[player.ActorNumber - 1] = new GameNetworkController.Player(player.ActorNumber, 100, OSController);

    }
    void Start()
    {
        if(!photonView.IsMine)
        {
            inputs.enabled = false;
        }
    }
}
