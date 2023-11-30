using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (Mathf.Abs(GameManager.instance.players[0].controller.transform.position.x - GameManager.instance.players[1].controller.transform.position.x) > 14 && cam.orthographicSize < 14)
            {
                cam.orthographicSize -= (cam.orthographicSize - Mathf.Abs(GameManager.instance.players[0].controller.transform.position.x - GameManager.instance.players[1].controller.transform.position.x)/2) * 3/30;
                this.transform.position = Vector3.right * (GameManager.instance.players[0].controller.transform.position.x + GameManager.instance.players[1].controller.transform.position.x) / 2 + Vector3.up*(cam.orthographicSize - 3) + Vector3.forward * -10;
            }
            if (Mathf.Abs(GameManager.instance.players[0].controller.transform.position.x - GameManager.instance.players[1].controller.transform.position.x) < 14 && cam.orthographicSize > 7)
            {
                cam.orthographicSize -= (cam.orthographicSize - 7) * 3 / 30;
                if(Mathf.Abs(this.transform.position.x -GameManager.instance.players[0].controller.transform.position.x) > 7 || Mathf.Abs(this.transform.position.x - GameManager.instance.players[1].controller.transform.position.x) > 7)
                {
                    this.transform.position = new Vector3(this.transform.position.x + (GameManager.instance.players[0].controller.transform.position.x-this.transform.position.x) / Mathf.Abs(GameManager.instance.players[0].controller.transform.position.x - this.transform.position.x) * 7/30, cam.orthographicSize - 3, -10);
                }
                else
                    this.transform.position = new Vector3(this.transform.position.x, cam.orthographicSize - 3, -10);
            }
        }
    }
}
