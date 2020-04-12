using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMePls : MonoBehaviour
{
    public Material orgMat;
    public Material hiddenMat;
     float duration;
    [SerializeField] LightingManager lightingManager;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // At start, use the first material
        rend.material = orgMat;
        duration = lightingManager.GetHourLength() * 12f;
    }

    void Update()
    {
        //     // ping-pong between the materials over the duration
        //     if (!lightingManager.IsNightTime())
        //     {
        //        // nightLerpTime = 0f;
        //         nightLerpTime += Time.deltaTime / divideFactor;
        //         rend.material.Lerp(orgMat, hiddenMat, nightLerpTime);
        //     }                                                        
        //     else
        //     {
        //        // nightLerpTime = 0f;
        //         nightLerpTime += Time.deltaTime / divideFactor;
        //         rend.material.Lerp(hiddenMat, orgMat, nightLerpTime);
        //     }


            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.Lerp(orgMat, hiddenMat, lerp);

    }
}
