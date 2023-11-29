using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HitTaken : State
{
    private int cantMoveFrames = 0;
    private int counter = 0;
    private float knockBack;
    private float deceleration = 5f;
   protected override void OnEnter(float valueToPassOne, float valueToPassTwo)
    {
        cantMoveFrames = (int)valueToPassOne;
        knockBack = valueToPassTwo;
        controller.anim.SetTrigger("Hurt");
    }
    protected override void OnUpdate()
    {
        if ((knockBack * Time.deltaTime - 1 / 2 * 5 * (Time.deltaTime * Time.deltaTime)) >= 0)
            controller.transform.position.x += knockBack * Time.deltaTime - 1 / 2 * 5 * (Time.deltaTime * Time.deltaTime);
        if(counter >= cantMoveFrames)
        {
            cancel = true;
            moveOver = true;
            controller.SetState(controller.idle);
        }

        counter++;
    }
    protected override void OnExit() 
    {
        controller.anim.SetTrigger("Recovered");  
    }
}
