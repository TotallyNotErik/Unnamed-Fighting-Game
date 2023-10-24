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

    }

    public void Jump()
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
        if (cancel) ;
            //Move Left
    }
    public override void OnRight() //replace with forward function and backward function
    {
        if (cancel) ; 
            //Move Right
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
