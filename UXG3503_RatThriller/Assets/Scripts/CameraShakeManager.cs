using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShakeManager : MonoBehaviour
{
    
    //reference impulse source
    private CinemachineImpulseSource camerashakeSource;
    void Start()
    { 
        

        //Subscribe to onCameraShakeTriggered Event
        EventManager.current.onCameraShakeTriggered += GenerateImpulse;
        //intialize impulse source
        camerashakeSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnDestroy()
    {
        //Unsubscribe to onCameraShakeTriggered Event
        EventManager.current.onCameraShakeTriggered -= GenerateImpulse;
    }

    //Generate Screen Shake
    public void GenerateImpulse()
    {
        
        camerashakeSource.GenerateImpulse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
