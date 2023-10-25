using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public StateController controller;

    protected bool cancel;

    public void OnStateEnter(StateController controller)
    {
        this.controller = controller;
        cancel = false;
        OnEnter();
    }
    protected virtual void OnEnter()
    {

    }
    public void OnStateEnter(float takeOffTime, StateController controller)
    {
        //Code here will always run
        this.controller = controller;
        OnEnter(takeOffTime);
    }
    protected virtual void OnEnter(float takeOffTime)
    {
        OnEnter(takeOffTime);
    }

    public void OnStateUpdate()
    {
        //Get Input information
        //Input Buffer
        OnUpdate();
    }
    protected virtual void OnUpdate()
    {

    }

    public void OnStateExit()
    {
        //Code here will always run
        OnExit();
    }
    protected virtual void OnExit()
    {

    }

    public virtual void OnHit()
    {
        //Switch to Hit Animation
        controller.SetState(controller.hitTaken);
    }

    public virtual void OnJump()
    {

    }
    public virtual void OnPunch()
    {

    }
    public virtual void OnLeft()
    {
        if (controller.transform.position.x - controller.opponent.transform.position.x < 0)
        {
            OnBackward();
        }
        else
            OnForward();
    }
    public virtual void OnRight()
    {
        if (controller.transform.position.x - controller.opponent.transform.position.x < 0)
        {
            OnForward();
        }
        else
        {
            OnBackward();
        }
    }
    public virtual void OnDown()
    {

    }
    public virtual void OnKick() { }
    public virtual void OnJab() { }

    public virtual void OnForward() { }
    public virtual void OnBackward() { }
}

