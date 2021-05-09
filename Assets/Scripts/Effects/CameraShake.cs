using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeTime = 0.2f;
    [SerializeField] private float _shakeAmplitude = 4f;
    [SerializeField] private Events.Type _eventName;
    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _mcPerlin;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _mcPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void OnEnable()
    {
        EventManager.StartListening( _eventName, StartShake );
    }

    void OnDisable()
    {
        EventManager.StopListening( _eventName, StartShake );
    }

    void StopShake()
    {
        _mcPerlin.m_AmplitudeGain = 0f;
    }
    IEnumerator DelayedStop()
    {
        yield return new WaitForSeconds( _shakeTime );
        StopShake();
    }

    void StartShake()
    {
        _mcPerlin.m_AmplitudeGain = _shakeAmplitude;
        StartCoroutine( DelayedStop() );
    }
}
