using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header("Aim")]
    [SerializeField] Transform cameraArm;
    [SerializeField] Transform projectileSocket;
    [SerializeField] Transform cam;
    [SerializeField] Transform flame;
    [Header("Adjustable Values")]
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] float clampMin = -35f;
    [SerializeField] float clampMax = 60f;


    float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        CamControl();
    }
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, clampMin, clampMax);

        cam.transform.LookAt(cameraArm);

        cameraArm.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        projectileSocket.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        flame.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
