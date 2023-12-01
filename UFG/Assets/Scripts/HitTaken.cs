using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/*The HitTaken class will cancel any current actions and lock the user into a hitstun*/
public class HitTaken : State
{
    private int cantMoveFrames = 0;
    private int counter = 0;
    private float knockBack;
    private float deceleration = 5f;
    private int coefficient;

   protected override void OnEnter(float valueToPassOne, float valueToPassTwo)
    {
        counter = 0;
        cantMoveFrames = (int)valueToPassOne;
        knockBack = valueToPassTwo;
        controller.anim.SetTrigger("Hurt");
        if (controller.transform.position.x - controller.opponent.transform.position.x < 0)
        {
            coefficient = -1;
        }
        else
        {
            coefficient = 1;
        }
    }
    protected override void OnUpdate()
    {
          
            if ((Mathf.Abs(knockBack * (coefficient) - deceleration * (coefficient) * 1/30 )) >= 0 && Mathf.Abs(controller.transform.position.x + (knockBack * (coefficient) - deceleration * (coefficient) * 1 / 30) * 1 / 30) < 10)
            {
                controller.transform.position += new Vector3((knockBack* (coefficient) - deceleration* (coefficient) * 1/30) * 1/30, 0, 0);
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
        controller.anim.SetTrigger("Recovered");  
    }
}
