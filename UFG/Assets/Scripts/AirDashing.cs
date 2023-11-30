using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDashing : State
{
    public static int airDashes = 2;
    private int i = 0;
    private float dashCoefficient;
    protected override void OnEnter()
    {
        i = 0;
        if (airDashes <= 0)
            i = 9;
        cancel = false;
        moveOver = false;
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
        airDashes--;
    }

    protected override void OnUpdate()
    {
        if (i > 6)
        {
            moveOver = true;
            controller.SetState(controller.inAir, 0, controller.walkSpeed * 2 * dashCoefficient);
        }
        else if (i > 5)
            cancel = true;
        if (i > 3 && Mathf.Abs(controller.transform.position.x + controller.walkSpeed * 3 * Time.deltaTime * dashCoefficient) < 10)
            controller.transform.position += new Vector3(controller.walkSpeed * 3 * Time.deltaTime * dashCoefficient, 0, 0);
        i++;

    }
}
