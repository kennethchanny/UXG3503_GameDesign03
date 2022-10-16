﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    private Animator animRef;

    private void Start()
    {
        animRef = GetComponent<Animator>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartTransition()
    {
        animRef.SetTrigger("TransitionOut");
    }
    public void NextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    ///////////////////////Nicole added below
    public Animation animatorMainMenu;
    public void PlayMMPuppetAnim()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animatorMainMenu.Play("MainMenu");
    }

}
