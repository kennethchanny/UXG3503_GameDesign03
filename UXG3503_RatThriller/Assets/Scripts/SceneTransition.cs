using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    private Animator animRef;

    private void Start()
    {
        animRef = GetComponent<Animator>();
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
}
