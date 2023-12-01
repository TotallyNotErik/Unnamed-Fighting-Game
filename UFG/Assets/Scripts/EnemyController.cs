using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateController
{
    protected override void OverrideStart()
    {
        GameManager.instance.makeBot(this);
    }
}
