using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : Grounded
{
    protected int hitStun;
    protected float knockBack;
    protected int moveFrames;
    protected int frameCount;


    protected override void OnEnter()
    {
        controller.transform.GetChild(0).GetChild(0).GetComponent<Hitbox>().hitStun = this.hitStun;
        controller.transform.GetChild(0).GetChild(0).GetComponent<Hitbox>().knockBack = this.knockBack;
        frameCount = 0;
        playAnimation(true);
    }
    protected virtual void playAnimation(bool activate)
    {

    }
    protected override void OnGroundChildUpdate()
    {
        frameCount++;
        if (frameCount > moveFrames)
        {
            cancel = true;
            moveOver = true;
            playAnimation(false);
        }
    }
    protected override void OnExit()
    {
        playAnimation(false);
    }

}
