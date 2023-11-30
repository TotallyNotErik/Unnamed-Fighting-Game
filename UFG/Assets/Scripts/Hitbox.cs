using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int hitStun;
    public float knockBack;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform == this.transform.parent.parent)
        {
            return;
        }
        else {
            col.gameObject.GetComponent<StateController>().currentState.OnHit(hitStun, knockBack);
            GameManager.instance.Hit();
        }
    }
}
