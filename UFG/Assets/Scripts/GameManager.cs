using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
