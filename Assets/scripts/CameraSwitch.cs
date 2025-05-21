using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera cabinetCamera;

    public void SwitchToCabinetCamera()
    {
        mainCamera.enabled = false;
        cabinetCamera.enabled = true;
    }

    public void SwitchToMainCamera()
    {
        cabinetCamera.enabled = false;
        mainCamera.enabled = true;
    }

}
