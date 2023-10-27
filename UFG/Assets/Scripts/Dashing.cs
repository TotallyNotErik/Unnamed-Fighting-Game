using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : Grounded
{

    private int i = 0;
    private float dashCoefficient;
    protected override void OnEnter()
    {
        if (controller.transform.position.y > 0)
        {
            controller.SetState(controller.airDashing);
        }

        if (controller.transform.position.x - controller.opponent.transform.position.x <= 0)
        {
            if (forwardBack.z == 10)
            {
                dashCoefficient = -0.5f;
            }

            else
            {
                dashCoefficient = 1f;
            }

        }
        else if (controller.transform.position.x - controller.opponent.transform.position.x > 0)
        {
            if (forwardBack.z == 10)
            {
                dashCoefficient = 0.5f;
            }

            else
            {
                dashCoefficient = -1f;
            }

        }
        i = 0;
        cancel = false;
        moveOver = false;
    }
    protected override void OnGroundChildUpdate()
    {

        if (i > 3)
            controller.transform.position += new Vector3(controller.walkSpeed * 3 * Time.deltaTime * dashCoefficient, 0, 0);

        if (i > 6)
            cancel = true;
        if (i > 8)
        {
            moveOver = true;
            controller.SetState(controller.idle);
        }
        i++;
    }

    public override void OnLeft() 
    {
        if (cancel || moveOver)
        {
            if (controller.transform.position.x - controller.opponent.transform.position.x <= 0)
            {
                controller.SetState(controller.walkingBackwards,-1);
            }
            else if (controller.transform.position.x - controller.opponent.transform.position.x > 0)
            {
                controller.SetState(controller.running,-1); //change to running
            }
        }
    }
    public override void OnRight() 
    {
        if (cancel || moveOver)
        {
            if (controller.transform.position.x - controller.opponent.transform.position.x <= 0)
            {
                controller.SetState(controller.running,1); //change to running
            }
            else if (controller.transform.position.x - controller.opponent.transform.position.x > 0)
            {
                controller.SetState(controller.walkingBackwards,1);
            }
        }
    }

    public override void OnKick() { }
    public override void OnJab() { }
    public override void OnPunch()
    {

    }

}
