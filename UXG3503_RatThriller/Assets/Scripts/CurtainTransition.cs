using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainTransition : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animref;
    private InGameDialogue theshowgoon;
    public postprocess postprocessref;


    void Start()
    {
        animref = GetComponent<Animator>();
        theshowgoon = GameObject.Find("TheShowMustGoOn!").GetComponent<InGameDialogue>();
        EventManager.current.onGameOver += CurtainClose;
      
    }


    private void OnDestroy()
    {
        EventManager.current.onGameOver -= CurtainClose;
    }

    public void TurnOffPost()
    {
        postprocessref.OffPP();
    }

    public void TurnOnPost()
    {
        postprocessref.OnPP();
    }
    public void CurtainClose()
    {
        animref.SetTrigger("GameOver");
    }

    public void TriggerWords()
    {
        theshowgoon.StartDialogue();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
