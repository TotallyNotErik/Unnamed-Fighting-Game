using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : State
{
    protected override void OnEnter()
    {
        //Play Idle Animation
    }
    protected override void OnUpdate()
    {
        if (upwardInput.x == 1 || upwardInput.y == 1 || upwardInput.z == 1)
            OnJump();
        else if (upwardInput.z == 4)
            OnDown();
        else if (sidewaysInput.z == 2)
            OnLeft();
        else if (sidewaysInput.z == 3)
            OnRight();
        else if (sidewaysInput.z == 0)
            controller.SetState(controller.idle);
        OnGroundChildUpdate();
    }
    protected virtual void OnGroundChildUpdate() { }

    protected void Jump()
    {
        controller.SetState(controller.inAir, Time.time);
    }
    public override void OnJump()
    {
        if (cancel)
            Jump();
    }

    public override void OnPunch()
    {
        if (cancel) ;
            //Punch();
    }
    public override void OnLeft() //replace with forward function and backward function
    {
        int direction = -1;
        if (cancel)
        {
            if(forwardBack.z == 8)
            {
                controller.SetState(controller.walking, direction);
            }
            else if(forwardBack.z == 9)
            {
                controller.SetState(controller.walkingBackwards, direction);
            }
        }
        //Move Left
    }
    public override void OnRight() //replace with forward function and backward function
    {
        int direction = 1;
        if (cancel)
        {
            if (forwardBack.z == 8)
            {
                controller.SetState(controller.walking, direction);
            }
            else if (forwardBack.z == 9)
            {
                controller.SetState(controller.walkingBackwards, direction);
            }
        }
    }
    public override void OnDown()
    {
        if (cancel) ;
            //Crouch

    }
    public override void OnKick()
    {
        if (cancel) ;
            //Kick
    }
    public override void OnJab()
    {
        if (cancel) ;
            //Jab
    }
}
