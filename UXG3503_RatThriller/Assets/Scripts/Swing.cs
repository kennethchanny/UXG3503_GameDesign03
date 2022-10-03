using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float moveSpeed = 0;
    public int leverDirection = 0;
    public Transform rightrope;
    public Transform leftrope;

    public void DebugToggleLever()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            ToggleLever();
            Debug.Log(leverDirection);
        }
    }

    public void ToggleLever()
    {
        switch (leverDirection)
        {

            case 0:
                {
                    leverDirection = 1;
                }
                break;
            case 1:
                {
                    leverDirection = -1;
                }
                break;
            case -1:
                {
                    leverDirection = 1;
                }
                break;


        }


    }
    public void MoveCage(int dir)
    {
        rightrope.Translate(moveSpeed * dir, 0, 0);
        leftrope.Translate(moveSpeed * dir, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        DebugToggleLever();
    }
    private void FixedUpdate()
    {

        MoveCage(leverDirection);
    

    }
}
