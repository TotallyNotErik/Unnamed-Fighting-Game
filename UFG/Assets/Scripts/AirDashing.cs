using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDashing : State
{
    private bool dashended = false;
    protected override void OnEnter()
    {

        if (controller.transform.position.x - controller.opponent.transform.position.x <= 0)
        {
            if (forwardBack.z == 10)
                Debug.Log("BackDash air Left");
            else
                Debug.Log("Dash air Right");
        }
        else if (controller.transform.position.x - controller.opponent.transform.position.x > 0)
        {
            if (forwardBack.z == 10)
                Debug.Log("BackDash  air right");
            else
                Debug.Log("Dash air left");
        }
        cancel = true;
        dashended = true;
    }

    protected override void OnUpdate()
    {
        if (dashended)
            controller.SetState(controller.inAir, 0);
    }
}
