using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class StateController : MonoBehaviour
{
    State currentState;
    public Idle idle;
    public InAir inAir;

    [Header("Character Stats")]
    public float jumpVelocity;
    public float walkSpeed;
    public float runSpeed;


    void Start()
    {
        idle = new Idle();
        inAir = new InAir(jumpVelocity);
        //walking = new Walking(walkSpeed);
        //running = new Running(runSpeed);
    }
    public void Update ()
    {
        currentState.OnStateUpdate();
        OverriddenUpdate();
    }

    protected virtual void OverriddenUpdate ()
    {

    }
    public void SetState(State state)
    {
        if (state == currentState) return;
        else if (currentState != null) currentState.OnStateExit();
        
        currentState = state;
    }
}
