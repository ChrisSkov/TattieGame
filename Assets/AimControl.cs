using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControl : MonoBehaviour
{
   // Camera cam;
    [SerializeField] GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aim.transform.rotation = Camera.main.transform.rotation;
    }
}
