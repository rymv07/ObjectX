using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
    public bool brake;
    public bool freewheel; //for non-4wd cars
}

public class DriveWheel : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float resistanceFriction = 0f;
        float restforce = 0f;

        float resTorque = maxMotorTorque; // Getting the value of maxMotorTorque for resistanceTorque
        float brakeTorque = (resTorque / 3) + resTorque; // Get the Value of maxMotorTorque plus 1/3 of its value.


        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float freewheel = resistanceFriction * Input.GetAxisRaw("Vertical");

        float brake = (brakeTorque * 1f) + restforce; // Declares the Value of BrakeTorque for brake.

        foreach (AxleInfo axleInfo in axleInfos)
        {

            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (axleInfo.freewheel)
            {
                axleInfo.leftWheel.brakeTorque = freewheel;
                axleInfo.rightWheel.brakeTorque = freewheel;
            }

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                axleInfo.leftWheel.brakeTorque = restforce;
                axleInfo.rightWheel.brakeTorque = restforce;

                // Handbrake is Released
            }

            if (axleInfo.brake)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    axleInfo.leftWheel.brakeTorque = brake;
                    axleInfo.rightWheel.brakeTorque = brake;
                    axleInfo.leftWheel.motorTorque = restforce;
                    axleInfo.rightWheel.motorTorque = restforce;

                    // Handbrake is Activated
                }
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);


        }
    }
}