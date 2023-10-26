using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public StateController controller;

    protected bool cancel;

    protected Vector3 sidewaysInput = new Vector3(0,0,0);
    protected Vector3 upwardInput = new Vector3(0, 0, 0);
    protected Vector3 actionInput = new Vector3(0, 0, 0);
    protected Vector3 forwardBack = new Vector3(0, 0, 0);
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
    protected virtual void OnEnter(float valueToPass)
    {

    }

    public void OnStateUpdate()
    {
        //Read Input Buffer
        readInputBuffer();
        if (actionInput.z == 5 || actipnInput.y == 5 || actionInput.x == 5)
            OnDash();
        OnUpdate();
    }
    protected virtual void OnUpdate()
    {

    }

    public void OnStateExit()
    {
        //Code here will always run
        cancel = false;
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
    public virtual void OnDash()
    {

    }
    public virtual void OnKick() { }
    public virtual void OnJab() { }

    public virtual void OnForward() { }
    public virtual void OnBackward() { }
    private void readInputBuffer() 
    {
                sidewaysInput.x = (int)controller.inputs[Mathf.Clamp(controller.i - 2, 0, 29)].One;
                sidewaysInput.y = (int)controller.inputs[Mathf.Clamp(controller.i - 1, 0, 29)].One;
                sidewaysInput.z = (int)controller.inputs[controller.i].One;

                upwardInput.x = (int)controller.inputs[Mathf.Clamp(controller.i - 2, 0, 29)].Two;
                upwardInput.y = (int)controller.inputs[Mathf.Clamp(controller.i - 1, 0, 29)].Two;
                upwardInput.z = (int)controller.inputs[controller.i].Two;
 
                actionInput.x = (int)controller.inputs[Mathf.Clamp(controller.i - 2, 0, 29)].Three;
                actionInput.y = (int)controller.inputs[Mathf.Clamp(controller.i - 1, 0, 29)].Three;
                actionInput.z = (int)controller.inputs[controller.i].Three;

                forwardBack.x = (int)controller.inputs[Mathf.Clamp(controller.i - 2, 0, 29)].Four;
                forwardBack.y = (int)controller.inputs[Mathf.Clamp(controller.i - 1, 0, 29)].Four;
                forwardBack.z = (int)controller.inputs[controller.i].Four;

        //Debug.Log(sidewaysInput);
        //Debug.Log(upwardInput);
        //Debug.Log(actionInput);
        //Debug.Log(forwardBack);

    }
}

