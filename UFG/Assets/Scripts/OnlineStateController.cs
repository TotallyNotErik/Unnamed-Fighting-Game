using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using Photon.Pun;
using Photon.Realtime;

public class OnlineStateController : StateController
{
    public override bool isOnline() { return true; }
    public NetworkController netController;
    /*Allows for children classes to add stuff that is unique to them */
    protected override void OverriddenUpdate ()
    {
        
    }



}
