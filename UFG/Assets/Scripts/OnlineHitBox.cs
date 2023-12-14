using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class OnlineHitBox : MonoBehaviour
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
               GameNetworkController.instance.photonView.RPC("Hit", RpcTarget.All, col.transform.parent.parent.gameObject.GetComponent<StateController>().id, (int)knockBack /2);
            }
            else
                GameNetworkController.instance.photonView.RPC("Hit", RpcTarget.All, col.transform.parent.parent.gameObject.GetComponent<StateController>().id, (int)knockBack);
        }
    }
}
