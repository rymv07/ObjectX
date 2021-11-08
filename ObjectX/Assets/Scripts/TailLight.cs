using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailLight : MonoBehaviour
{
    public GameObject tailLightsOn;
    public GameObject tailLightsOff;
    public Light tailLights;


    // Start is called before the first frame update
    void Start()
    {
        tailLightsOn.SetActive(false);
        tailLightsOff.SetActive(true);
        tailLights.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            tailLights.enabled = true;
            tailLightsOn.SetActive(true);
            tailLightsOff.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            tailLights.enabled = false;
            tailLightsOn.SetActive(false);
            tailLightsOff.SetActive(true);
        }

    }
}
