using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivityX = 1f, sensitivityY = 1f;
    public enum Options { X, Y, XandY }
    public Options options;
    private Quaternion targetRot;

    void Start()
    {
        targetRot = transform.rotation;
    }

    void Update()
    {
        float rotX = Input.GetAxis("Mouse Y") * sensitivityY;
        float rotY = Input.GetAxis("Mouse X") * sensitivityX;
    
        switch (options) {
            case Options.X:
                targetRot *= Quaternion.Euler(-rotX, 0.0f, 0.0f);
                break;
            case Options.Y:
                targetRot *= Quaternion.Euler(0.0f, rotY, 0.0f);
                break;
            case Options.XandY:
                targetRot *= Quaternion.Euler(-rotX, rotY, 0.0f);
                break;
        }

        transform.localRotation = targetRot;
    }
}