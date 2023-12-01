using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : Grounded
{

    private int i = 0;
    private float dashCoefficient;

    /*OnEnter will Determine the direction and speed of the dash depending on userInput*/
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
    /* Overrides the GroundChildUpdate to move the character for x amount of frames */
    protected override void OnGroundChildUpdate()
    {

        if (i > 1 && Mathf.Abs(controller.transform.position.x + controller.walkSpeed * 3 * Time.deltaTime * dashCoefficient) < 10)
            controller.transform.position += new Vector3(controller.walkSpeed * 3 * Time.deltaTime * dashCoefficient, 0, 0);

        if (i > 4)
            cancel = true;
        if (i > 6)
        {
            moveOver = true;
            controller.SetState(controller.idle);
        }
        i++;
    }

    /*Sets the player to running after a dash*/
    public override void OnLeft() 
    {
            if (controller.transform.position.x - controller.opponent.transform.position.x <= 0)
            {
                if(cancel || moveOver)
                    controller.SetState(controller.walkingBackwards,-1);
            }
            else if (controller.transform.position.x - controller.opponent.transform.position.x > 0)
            {

                controller.SetState(controller.running, -1);

        }

    }
    public override void OnRight() 
    {


            if (controller.transform.position.x - controller.opponent.transform.position.x <= 0)
            {
                controller.SetState(controller.running,1);
            }
            else if (controller.transform.position.x - controller.opponent.transform.position.x > 0)
            {
                if(cancel||moveOver)
                    controller.SetState(controller.walkingBackwards,1);
            }

    }

    /*Since you can't kick Jab or Punch during a dash, override the functions to do nothing*/
    public override void OnKick() { }
    public override void OnJab() { }
    public override void OnPunch() { }
}
