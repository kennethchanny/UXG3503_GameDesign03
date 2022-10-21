using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;


    //Initialize Event manager
    private void Awake()
    {
        current = this;
    }


    //FUNCTIONS TO NOTE
    //Calling the event--------------------
    //EventManager.current.EventTriggered()

    //Subscribing to the event ------------ (Start Func)
    //EventManager.current.onEventTriggered += (Function);

    //Unsubscribing to the event ---------- (OnDestroy Func)
    //EventManager.current.onEventTriggered -= (Function);


    public event Action onCameraShakeTriggered;
    public void CameraShakeTriggered()
    {
        if (onCameraShakeTriggered != null)
        {
            onCameraShakeTriggered();
        }

    }

    public event Action onGameOver;
    public void GameOverTriggered()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }

    }

    public event Action<int> onLeverPulled;
    public void LeverPulled(int id)
    {
        if (onLeverPulled != null)
        {
            onLeverPulled(id);
        }

    }
}