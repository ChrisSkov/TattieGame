﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
