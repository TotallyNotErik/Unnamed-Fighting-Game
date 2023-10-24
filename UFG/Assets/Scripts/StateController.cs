using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public GameObject opponent;
    public Idle idle;
    public InAir inAir;
    public Walking walking;
    public Running running;
    public HitTaken hitTaken;
    public HeavyHitTaken heavyHitTaken;

    [Header("Character Stats")]
    public State currentState;
    public float jumpVelocity;
    public float walkSpeed;
    public float runSpeed;


    void Start()
    {
        idle = new Idle();
        inAir = new InAir(jumpVelocity);
        walking = new Walking(walkSpeed);
        hitTaken = new HitTaken();
        //running = new Running(runSpeed);

        SetState(idle);
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

        Debug.Log("State Set!");
        currentState = state;
        currentState.OnStateEnter(this);
    }
    public void SetState(State state, float takeOffTime)
    {
        if (state == currentState) return;
        else if (currentState != null) currentState.OnStateExit();

        currentState = state;
        currentState.OnStateEnter(takeOffTime, this);
    }

    void OnJump()
    {
        if (currentState != null) currentState.OnJump();
    }

    void OnRight()
    {
        if (currentState != null) currentState.OnRight();
    }
    void OnLeft()
    {
        if (currentState != null) currentState.OnLeft();
    }
    void OnPunch()
    {
        if(currentState != null) currentState.OnPunch();
    }
    void OnDown()
    {
        if(currentState != null) currentState.OnDown();
    }
    void OnKick()
    {
        if(currentState != null) currentState.OnKick();
    }
    void OnJab()
    {
        if(currentState != null) currentState.OnJab();
    }
}
