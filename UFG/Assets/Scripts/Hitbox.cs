using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int hitStun;
    public float knockBack;
    /*This script detects if the hitbox has a hurtbox in its area.  If it does, it will check if the hitbox is attached to the same player
     If not attached to the same player, the hitbox will apply knockback, hitstun, and deal damage to the target. */
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.parent == this.transform.parent)
        {
            return;
        }
        else
        {
            col.transform.parent.parent.gameObject.GetComponent<StateController>().currentState.OnHit(hitStun, knockBack);
            if (col.transform.parent.parent.gameObject.GetComponent<StateController>().currentState == col.transform.parent.parent.gameObject.GetComponent<StateController>().blocking || col.transform.parent.parent.gameObject.GetComponent<StateController>().currentState == col.transform.parent.parent.gameObject.GetComponent<StateController>().walkingBackwards)
            {
                GameManager.instance.Hit(col.transform.parent.parent.gameObject.GetComponent<StateController>().id, (int)knockBack /2);
            }
            else 
                GameManager.instance.Hit(col.transform.parent.parent.gameObject.GetComponent<StateController>().id, (int)knockBack);
        }
    }
}
