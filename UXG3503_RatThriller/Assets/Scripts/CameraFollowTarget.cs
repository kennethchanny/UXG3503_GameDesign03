using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform playertransform1;
    public Transform playertransform2;
    public Transform camerafollowtarget;
    public float playerseparation;
    public float maxseparation;


    private float shakeinterval = 0.7f;
    private bool shaketriggered = false;

    public float zoomLimiter = 10f;
    private CinemachineVirtualCamera ingamecamera;

    public float minZoom = 2f;
    public float maxZoom = 4f;

    void Start()
    {
        camerafollowtarget.position = 0.5f*(playertransform1.position + playertransform2.position);
        ingamecamera = GameObject.Find("InGameCamera").GetComponent<CinemachineVirtualCamera>();
    }

    void UpdateCamera()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, playerseparation / zoomLimiter);
        ingamecamera.m_Lens.OrthographicSize = Mathf.Lerp(ingamecamera.m_Lens.OrthographicSize, newZoom, Time.deltaTime);
    }

    void UpdateCameraShake()
    {
        
        

        if (shaketriggered == false)
        {
            if (playerseparation > maxseparation)
            {
                EventManager.current.CameraShakeTriggered();
                shaketriggered = true;
                shakeinterval = 0.7f;
            }

        }
        else
        {
            shakeinterval -= Time.deltaTime;
            if (shakeinterval <= 0)
            {
                shakeinterval = 0;
                shaketriggered = false;
            }
        }

       

    }

    void Update()
    {
        playerseparation = Vector2.Distance(playertransform1.position, playertransform2.position);
        camerafollowtarget.position = 0.5f * (playertransform1.position + playertransform2.position);

        UpdateCamera();
        UpdateCameraShake();
    }
}
