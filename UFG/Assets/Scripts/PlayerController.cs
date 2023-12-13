using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{


    private float startTime;
    private float timeTaken;

    private bool isPlaying;
    private int clicks;
    public GameObject playButton;
    public TextMeshProUGUI curTimeText;
    public TextMeshProUGUI clicksText;
    public Animator anim;


   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
            return;

        if(Input.GetMouseButtonUp(0))
        {
            clicks++;
            clicksText.text = clicks.ToString();
            anim.SetTrigger("click");
        }

        curTimeText.text = (Time.time - startTime).ToString("F2");
        if(Time.time - startTime >= 1)
        {
            End();
        }
    }
    public void Begin()
    {
        startTime = Time.time;
        isPlaying = true;
        clicks = 0;
        playButton.SetActive(false);
    }

    void End()
    {
        isPlaying = false;
        Leaderboard.instance.SetLeaderboardEntry(clicks);
        Invoke("waitForEnd", 5f);
    }
  
    void waitForEnd()
    {
        playButton.SetActive(true);
    }
}
