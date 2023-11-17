using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleroScript : MonoBehaviour
{
    public float tiltThreshold = 18.0f;
    public float frontTiltThreshold = 8.0f;
    public float backTiltThreshold = -8.0f;
    private Animator animator;
    private bool leftTiltTriggered = false;
    private bool rightTiltTriggered = false;
    private bool frontTiltTriggered = false;
    private bool backTiltTriggered = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // Quaternion Mathematics
        Quaternion gyroRotation = Input.gyro.attitude;

        // Numerator & Denominator calculation
        float roll = Mathf.Atan2(2 * (gyroRotation.y * gyroRotation.w - gyroRotation.x * gyroRotation.z),
                                  1 - 2 * (gyroRotation.y * gyroRotation.y + gyroRotation.z * gyroRotation.z));

        roll = Mathf.Rad2Deg * roll;

        leftTiltTriggered = false;
        rightTiltTriggered = false;
        frontTiltTriggered = false;
        backTiltTriggered = false;

        if (roll > frontTiltThreshold)
        {
            animator.SetTrigger("FrontTilt");
            frontTiltTriggered = true;
        }
        else if (roll < backTiltThreshold)
        {
            animator.SetTrigger("BackTilt");
            backTiltTriggered = true;
        }
        else if (roll > tiltThreshold)
        {
            animator.SetTrigger("RightTilt");
            rightTiltTriggered = true;
        }
        else if (roll < -tiltThreshold)
        {
            animator.SetTrigger("LeftTilt");
            leftTiltTriggered = true;
        }
        else
        {
            animator.SetTrigger("Default");
        }
    }
}