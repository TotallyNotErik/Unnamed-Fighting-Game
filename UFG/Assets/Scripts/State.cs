using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public StateController controller;
    public void OnStateEnter()
    {
        //Code here will always run
        OnEnter();
    }
    protected virtual void OnEnter()
    {

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
    }
}

