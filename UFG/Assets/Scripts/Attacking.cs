using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Attacking is the base class for any attack actions.  
 * each attack has 3 values, hitstun: how many frames the opponent will not be able to move, knockBack: how far the opponent will be pushed, and moveFrames: how many frames the action takes to complete.
 * The character will be locked in the state until moveFrames amount of frames have passed*/
public class Attacking : Grounded
{
    protected int hitStun;
    protected float knockBack;
    protected int moveFrames;
    protected int frameCount;

 
    protected override void OnEnter()
    {
        if (controller.isOnline())
        {
            controller.transform.GetChild(0).GetChild(0).GetComponent<OnlineHitBox>().hitStun = this.hitStun;
            controller.transform.GetChild(0).GetChild(0).GetComponent<OnlineHitBox>().knockBack = this.knockBack;
        }
        else
        {
            controller.transform.GetChild(0).GetChild(0).GetComponent<Hitbox>().hitStun = this.hitStun;
            controller.transform.GetChild(0).GetChild(0).GetComponent<Hitbox>().knockBack = this.knockBack;
        }
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
