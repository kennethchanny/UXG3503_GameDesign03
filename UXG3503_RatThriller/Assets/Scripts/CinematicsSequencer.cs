using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicsSequencer : MonoBehaviour
{

    public static CinematicsSequencer current;
    private Animator anim;
    private void Awake()
    {
        current = this;

    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public enum CinematicsState
    {
        //In Dialogue state
        InGame,
        //In Cutscene state
        InCutscene,

    }
    //set state to InGame
    public CinematicsState currentState = CinematicsState.InGame;

    //Function to move to Cutscene
    public void CinematicManagerEnterCutsccene()
    {
        currentState = CinematicsState.InCutscene;

        
        anim.SetTrigger("InCutscene");

    }


    //Function to move to Default
    public void CinematicManagerEnterDefault()
    {
        currentState = CinematicsState.InGame;


        anim.SetTrigger("InGame");

    }

    void Update()
    {
        
    }
}
