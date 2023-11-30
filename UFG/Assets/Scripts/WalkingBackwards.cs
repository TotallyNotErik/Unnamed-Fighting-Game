using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBackwards : Walking
{
    public WalkingBackwards(float walkspeed) : base(walkspeed) { }
    

    public override void OnHit(int hitStun, float knockBack)
    {
        controller.SetState(controller.blocking, hitStun, knockBack);
    }

}
