using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    Rigidbody2D m_RB;
    Vector2 m_Force = Vector2.zero;
    public float m_MoveForce;
    public float m_maxmoveDist;

    private Vector3 m_startpos;
    private float spawndelaytimer = 0.7f;
 

    bool isScaling = false;
    public enum SwingState
    { 
        LEFT,
        RIGHT,
        IDLE
    }
    public SwingState m_currentstate = SwingState.IDLE;


    // Start is called before the first frame update
    public void MoveSwing(int id)
    {
        switch (id)
        {
            case 1:
                {
                    if(m_currentstate == SwingState.IDLE)
                    {
                        m_currentstate = SwingState.LEFT;
                    }

                    else if(m_currentstate == SwingState.LEFT)
                    {
                        m_currentstate = SwingState.IDLE;
                    }
                    else if (m_currentstate == SwingState.RIGHT)
                    {
                        //Zero out
                        m_Force = Vector2.zero;
                        m_RB.velocity = Vector2.zero;
                        m_currentstate = SwingState.LEFT;
                    }

                    //Go Left

                }
                break;
            case 2:
                {

                    if (m_currentstate == SwingState.IDLE)
                    {
                        m_currentstate = SwingState.RIGHT;
                    }

                    else if (m_currentstate == SwingState.RIGHT)
                    {

                        m_currentstate = SwingState.IDLE;
                    }
                    else if (m_currentstate == SwingState.LEFT)
                    {
                        //Zero out
                        m_Force = Vector2.zero;
                        m_RB.velocity = Vector2.zero;
                        m_currentstate = SwingState.RIGHT;
                    }
                    //Go right

                }
                break;
        }

    }


   
    void Start()
    {
        m_RB = GetComponent<Rigidbody2D>();
        //Store current position
        m_startpos = transform.position;

    }

    private void OnDestroy()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        m_RB.AddForce(m_Force, ForceMode2D.Force);
        gameObject.transform.GetChild(1).gameObject.GetComponent<Rigidbody2D>().AddForce(m_Force / 2, ForceMode2D.Force);

        gameObject.transform.GetChild(2).gameObject.GetComponent<Rigidbody2D>().AddForce(m_Force / 2, ForceMode2D.Force);

        m_Force = Vector2.zero;
    }
}
