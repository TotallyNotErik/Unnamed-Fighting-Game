using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Blocking : State
{
    int hitstaken = 0;
    int cantMoveFrames;
    float knockBack;
    int coefficient;
    float deceleration = 5f;
    int counter = 0;
    protected override void OnEnter (float valueToPassOne, float valueToPassTwo)
    {
        counter = 0;
        cantMoveFrames = (int)valueToPassOne / 2;
        knockBack = valueToPassTwo / 2;
        controller.transform.GetChild(1).gameObject.SetActive(true);
        if (controller.transform.position.x - controller.opponent.transform.position.x < 0)
        {
            coefficient = -1;
        }
        else
        {
            coefficient = 1;
        }
    }
    public override void OnHit(int hitStun, float knockBack)
    {
        hitstaken++;
        counter = 0;
        this.knockBack = knockBack / 2;
        cantMoveFrames = hitStun / 2;
        if (hitstaken > 3)
        {
            hitstaken = 0;
            base.OnHit(hitStun, knockBack);
        }
    }
    protected override void OnUpdate()
    {
        if ((Mathf.Abs(knockBack * (coefficient) - deceleration * (coefficient) * 1 / 30)) >= 0 && Mathf.Abs(controller.transform.position.x + (knockBack * (coefficient) - deceleration * (coefficient) * 1 / 30) * 1 / 30) < 10)
        {
            controller.transform.position += new Vector3((knockBack * (coefficient) - deceleration * (coefficient) * 1 / 30) * 1 / 30, 0, 0);
        }
        if (counter >= cantMoveFrames)
        {
            cancel = true;
            moveOver = true;
            controller.SetState(controller.idle);
            if (controller.transform.position.y > 0)
            {
                controller.SetState(controller.inAir, 0);
            }
        }

        counter++;
    }
    protected override void OnExit()
    {
        controller.transform.GetChild(1).gameObject.SetActive(false);
    }
}
