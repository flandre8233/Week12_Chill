using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Transform camTransform;
    // How long the object should shake for.
    static float shakeDuration = 0f;
    // Amplitude of the shake. A larger value shakes the camera harder.
    static float shakeAmount = 0.7f;
    static float OriginalAmount = 0f;
    static float OriginalDuration = 0f;
    float decreaseFactor = 1.0f;
    Vector3 originalPos;

    public static void Shake(float _shakeDuration, float _shakeAmount)
    {
        shakeDuration = _shakeDuration;
        shakeAmount = _shakeAmount;
        OriginalAmount = shakeAmount;
        OriginalDuration = _shakeDuration;
    }

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = transform;
        }
    }

    void Update()
    {
        if (IsShakeEnd())
        {
            ResetCamToNormal();
            return;
        }
        camTransform.localPosition = originalPos + (camTransform.rotation * Random.insideUnitCircle) * shakeAmount;
        shakeDuration -= Time.deltaTime * decreaseFactor;
        shakeAmount = Mathf.Lerp(OriginalAmount, 0, GetDurationLeftProgress());
    }

    bool IsShakeEnd()
    {
        return (shakeDuration <= 0);
    }

    float GetDurationLeftProgress()
    {
        return 1 - (shakeDuration / OriginalDuration);
    }

    void ResetCamToNormal()
    {
        shakeAmount = 0f;
        shakeDuration = 0f;
        camTransform.localPosition = new Vector3();
    }

}