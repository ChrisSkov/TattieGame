using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMePls : MonoBehaviour
{
    public Material moon;
    public Material hiddenMoon;
    float nightLerpTime = .0f;
    Renderer rend;
    [SerializeField] LightingManager lightingManager;
    void Start()
    {
        rend = GetComponent<Renderer>();

        // At start, use the first material
        rend.material = moon;
    }

    void Update()
    {
        // ping-pong between the materials over the duration
        if(!lightingManager.IsNightTime())
        {
              rend.material.Lerp(moon, hiddenMoon, 1f);
        }
        else
        {
            rend.material.Lerp(hiddenMoon, moon, 1f);
        }
    }
}
