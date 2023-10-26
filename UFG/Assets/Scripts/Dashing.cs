using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : Grounded
{

    protected override void OnEnter()
    {
        if(controller.transform.position.y > 0)
        {
            //controller.SetState(airDash);
        }

        if (controller.transform.position.x - controller.opponent.transform.position.x <= 0)
        { 
            if (forwardBack.z == 10)
                Debug.Log("BackDash Left");
            else
                Debug.Log("Dash Right");
        }
        else if (controller.transform.position.x - controller.opponent.transform.position.x > 0)
        {
            if (forwardBack.z == 10)
                Debug.Log("BackDash right");
            else
                Debug.Log("Dash left");
        }
        cancel = true;
    }

    public override void OnLeft()
    {
        if (controller.transform.position.x - controller.opponent.transform.position.x < 0)
        {
            OnBackward();
        }
        else
            OnForward();
    }
    public override void OnRight()
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
    public override void OnDash()
    {
        if(cancel)
            controller.SetState(controller.dashing);
    }

    public override void OnDown()
    {
        if (cancel)
        {
            //crouch
        }
    }
    public override void OnKick() { }
    public override void OnJab() { }
    public override void OnPunch()
    {

    }

}
