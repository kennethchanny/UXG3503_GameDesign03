using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator animref;

    private GameObject player1;
    private GameObject player2;

    public float leverDistance;
   

    void ToggleLever()
    {
        if(Vector2.Distance(player1.transform.position, transform.position) < leverDistance)
        {
      
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                animref.SetTrigger("ToggleLever");
            }
           
        }

        if (Vector2.Distance(player2.transform.position, transform.position) < leverDistance && Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                animref.SetTrigger("ToggleLever");
            }
        }

    }
    void Start()
    {
        animref = GetComponent<Animator>();
        player1 = GameObject.Find("GretelPlayer1");
        player2 = GameObject.Find("HanselPlayer2");
    }

    // Update is called once per frame
    void Update()
    {
        ToggleLever();
    }
}
