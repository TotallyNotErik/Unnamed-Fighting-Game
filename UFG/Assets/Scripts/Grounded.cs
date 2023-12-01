using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Grounded is the base state for any On-the-ground actions
 * Allows for inputs to be taken at any point, so creates a new overridable function to allow for even more code to be guaranteed to run.
 */
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
        else if (actionInput.x == 6 || actionInput.x == 6 || actionInput.x == 6)
            OnPunch();
        else if (actionInput.x == 7 || actionInput.x == 7 || actionInput.x == 7)
            OnKick();
        else if (actionInput.x == 8 || actionInput.x == 8 || actionInput.x == 8)
            OnJab();
        else if (upwardInput.z == 4)
            OnDown();
        else if (sidewaysInput.z == 2)
            OnLeft();
        else if (sidewaysInput.z == 3)
            OnRight();
        else if (sidewaysInput.z == 0 && moveOver && cancel)
            controller.SetState(controller.idle);

        OnGroundChildUpdate();
    }
    protected virtual void OnGroundChildUpdate() { }

    protected virtual void Jump()
    {
        controller.SetState(controller.inAir, controller.jumpVelocity,0);
    }
    public override void OnJump()
    {
        if (cancel)
            Jump();
    }

    public override void OnLeft() //replace with forward function and backward function
    {
        int direction = -1;
        if (cancel || moveOver)
        {
            if(forwardBack.z == 9)
            {
                controller.SetState(controller.walking, direction);
            }
            else if(forwardBack.z == 10)
            {
                controller.SetState(controller.walkingBackwards, direction);
            }
        }
        //Move Left
    }
    public override void OnRight() //replace with forward function and backward function
    {
        int direction = 1;
        if (cancel || moveOver)
        {
            if (forwardBack.z == 9)
            {
                controller.SetState(controller.walking, direction);
            }
            else if (forwardBack.z == 10)
            {
                controller.SetState(controller.walkingBackwards, direction);
            }
        }
    }
    public override void OnDown()
    {
        if (cancel) { }
    }
    public override void OnPunch()
    {
        if (cancel) { controller.SetState(controller.punching); }
    }
    public override void OnKick()
    {
        if (cancel) { controller.SetState(controller.kicking); }
    }
    public override void OnJab()
    {
        if (cancel) { controller.SetState(controller.jabbing); }
    }
}
