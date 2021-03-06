using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelect : MonoBehaviour
{
    public Camera mainCamera;
    public Camera chaseCamera;

    // Start is called before the first frame update
    void Start()
    {
        chaseCamera.enabled = true;
        mainCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            chaseCamera.enabled = true;
            mainCamera.enabled = false;
        }
        if (Input.GetKey("2"))
        {
            chaseCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
