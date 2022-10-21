using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float moveSpeed = 0;
    public int leverDirection = 0;
    public Transform rightrope;
    public Transform leftrope;
    public int id = 1;

  

    public void ToggleLever(int id)
    {
        if (id == this.id)
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


    }

    private void Start()
    {
        EventManager.current.onLeverPulled += ToggleLever;
    }

    private void OnDestroy()
    {
        EventManager.current.onLeverPulled -= ToggleLever;
    }
    public void MoveCage(int dir)
    {
        rightrope.Translate(moveSpeed * dir, 0, 0);
        leftrope.Translate(moveSpeed * dir, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {

        MoveCage(leverDirection);
    

    }
}
