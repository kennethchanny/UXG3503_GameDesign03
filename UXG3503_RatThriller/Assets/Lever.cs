using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator animref;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OI");
        if(collision.gameObject.tag == "Player")
        {
            switch (collision.gameObject.name)
            {

                case "GretelPlayer1":
                    {
                        if(Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            ToggleLever();
                        }
                    }
                    break;

                case "HanselPlayer2":
                    {
                        if (Input.GetKeyDown(KeyCode.S))
                        {
                            ToggleLever();
                        }
                    }
                    break;


            }

        }
    }

    void ToggleLever()
    {
        animref.SetTrigger("ToggleLever");
    }
    void Start()
    {
        animref = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
