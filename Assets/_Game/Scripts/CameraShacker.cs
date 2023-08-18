using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShacker : MonoBehaviour
{
    [Header("Camera Shaker Config")]
    Vector3 cameraInitialPosition;
    public Camera mainCamera;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;

    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.05f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;

        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }
    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }
}
