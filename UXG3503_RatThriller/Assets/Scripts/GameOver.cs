using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameOver = false;
    private CameraFollowTarget cameraref;
    [SerializeField] private float deathdecaytimer = 0;
    public float maxdeathDecay = 2f;
    void Start()
    {
        cameraref = GameObject.Find("CinemachineStateDrivenCamera").GetComponent<CameraFollowTarget>();
        deathdecaytimer = 0;
        gameOver = false;
    }

    // Update is called once per frame


    private void GameOverChecker()
    {

        //if game is over, dont continue
        if (gameOver == true) return;

        //if more than boundary, start countdown
        if (cameraref.playerseparation > cameraref.maxseparation)
        {
            //increase timer
            deathdecaytimer += Time.deltaTime;
            //if cross timer, gg
            if (deathdecaytimer > maxdeathDecay)
            {
                //die
                deathdecaytimer = 0;
                gameOver = true;
                EventManager.current.GameOverTriggered();
            }



        }

        //while more than boundary, if become less,
        if (cameraref.playerseparation < cameraref.maxseparation)
        {
            if (cameraref.playerseparation <= 0)
            {
                //heal up
                deathdecaytimer -= Time.deltaTime * 3;
                deathdecaytimer = 0;
            }

        }
    }
    void Update()
    {
        GameOverChecker();
    }
}
