using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLight : MonoBehaviour
{
    public GameObject headLightsOn;
    public GameObject headLightsOff;
   

    public Light headLights;
   


    // Start is called before the first frame update
    void Start()
    {
        headLightsOn.SetActive(false);
        headLightsOff.SetActive(true);
        headLights.enabled = false;
        

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey("l"))
        {
            headLights.enabled = true;
            headLightsOn.SetActive(true);
            headLightsOff.SetActive(false);
        } else if (Input.GetKey("k"))
        {
            headLights.enabled = false;
            headLightsOn.SetActive(false);
            headLightsOff.SetActive(true);
        }


    }
}
