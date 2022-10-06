/************************************************************************************//*!
\file           Button.cs
\author         Kenneth Chan, kenneth.chan, 380000519
\par            email: kenneth.chan\@digipen.edu
\date           Jan 17, 2022
\brief          Contains the definition of the Button class.
 
Copyright (C) 2022 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior written consent 
of DigiPen Institute of Technology is prohibited.
*//*************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Button : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    /*-----------------------------------------------------------------------------------------------------------------------*/
    /* Fields                                                                                                                */
    /*-----------------------------------------------------------------------------------------------------------------------*/


    //original scale to reset to
    private Vector3 originalScale;

    //boolean to lock scaling
    public bool scalingLock = false;

    //float for scale value
    public float scaleValue = 0.1f;

    //AudioScript reference
    private AudioScript audioRef;

    /*-----------------------------------------------------------------------------------------------------------------------*/
    /* Functions                                                                                                             */
    /*-----------------------------------------------------------------------------------------------------------------------*/

    #region Coroutines

    //Scale Button over time
    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (scalingLock == true)
        {
            //exit if this is still running
            yield break; 
        }

        //float counter
        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        //while counter is less than duration
        while (counter < duration)
        {
            //iterate counter with time
            counter += Time.deltaTime;
            //scale object
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }

        


    }

    IEnumerator ScaleBasedOnMouseEvent(string mouseevent)
    {
        //When a Mouse Event occurs, play custom sounds
        //Coroutine Process is separated so that each event can trigger their own sounds.
        switch (mouseevent)
        {
            case "hover":
                {
                    // Reset size, play sound and scale button, lock bool, delay abit then unlock bool 
                    transform.localScale = originalScale;
                    audioRef.playAudio();
                    StartCoroutine(scaleOverTime(transform, new Vector3(transform.localScale.x + scaleValue, 
                                                                        transform.localScale.y - scaleValue, 
                                                                        transform.localScale.z), 0.05f));
                    scalingLock = true;
                    yield return new WaitForSeconds(0.05f);
                    scalingLock = false;
                }
                break;


            case "exit":
                {
                    // play sound and scale button, lock bool, delay abit, reset size then unlock bool 

                    StartCoroutine(scaleOverTime(transform, new Vector3(transform.localScale.x - scaleValue,
                                                                        transform.localScale.y + scaleValue, 
                                                                        transform.localScale.z), 0.05f));
                    scalingLock = true;
                    yield return new WaitForSeconds(0.05f);
                    transform.localScale = originalScale;
                    scalingLock = false;
                }
                break;

            case "clickdown":
                {
                    // Reset size, play sound and scale button, lock bool, delay abit then unlock bool 

                    
                    transform.localScale = originalScale;
                    audioRef.playAudio2();
                    StartCoroutine(scaleOverTime(transform, new Vector3(transform.localScale.x + scaleValue,
                                                                        transform.localScale.y - scaleValue, 
                                                                        transform.localScale.z), 0.05f));
                    scalingLock = true;
                    yield return new WaitForSeconds(0.05f);
                    scalingLock = false;
                }
                break;

            case "clickup":
                {
                    // play sound and scale button, lock bool, delay abit, Reset size, then unlock bool 

                    audioRef.playAudio3();
                    StartCoroutine(scaleOverTime(transform, new Vector3(transform.localScale.x + scaleValue,
                                                                        transform.localScale.y - scaleValue, 
                                                                        transform.localScale.z), 0.05f));
                    scalingLock = true;
                    yield return new WaitForSeconds(0.05f);
                    transform.localScale = originalScale;
                    scalingLock = false;
                }
                break;

            default:
                {
                    Debug.Log("String Parameter does not exist!");
                }
                break;


        }

        
    }
    
    #endregion

    #region MouseEvents

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        StartCoroutine(ScaleBasedOnMouseEvent("exit"));

    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        StartCoroutine(ScaleBasedOnMouseEvent("hover"));
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        StartCoroutine(ScaleBasedOnMouseEvent("clickdown"));
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        StartCoroutine(ScaleBasedOnMouseEvent("clickup"));
    }

    #endregion


    /*-----------------------------------------------------------------------------------------------------------------------*/
    /* Main                                                                                                                  */
    /*-----------------------------------------------------------------------------------------------------------------------*/

    void Start()
    {
        //Set original scale
        originalScale = transform.localScale;
        //Initilize audioscript
        audioRef = GetComponent<AudioScript>();
    }

   
}
