using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Material daySky;
    [SerializeField] Material nightSky;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            RenderSettings.skybox = daySky;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            RenderSettings.skybox = nightSky;
        }
    }
}
