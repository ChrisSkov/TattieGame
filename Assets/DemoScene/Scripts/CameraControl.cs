using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    [SerializeField] float sensitivity = 1f;
    [SerializeField] float clampMin = -10f;
    [SerializeField] float clampMax = 10f;
 
    CinemachineComposer composer;
    // Start is called before the first frame update
    void Start()
    {
       
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * sensitivity;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, clampMin, clampMax);
   
    }
}






