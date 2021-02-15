//***********************************
// BallController.cs
// - Morgan Ethier
// - Created for GAME3002_A1
//***********************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    float posHoriz;

    [SerializeField]
    float posVert;
    
    [SerializeField]
    float posDepth;

    [SerializeField]
    float angleDegVert;

    [SerializeField]
    float angleDegHoriz;

    bool isActivated;

    float posHorizInit;
    float velocity;

    bool timeStarted;
    float startTime;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        //init variables

        //Default ball position
        posHoriz = 0.0f;
        posHorizInit = 0.0f;
        posVert = 1.0f;
        posDepth = -14.5f;

        //Default ball aim
        angleDegVert = 0.0f;
        angleDegHoriz = 0.0f;

        //Velocity
        velocity = 10.0f;

        //Used while running
        isActivated = false;
        timeStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if simulation running
        if(!isActivated)
        {
            //Move/Aim Ball

            //Position ball left/right
            if (Input.GetKeyDown("a"))
            {
                posHoriz -= 0.1f;
                posHorizInit -= 0.1f;
            }

            if (Input.GetKeyDown("d"))
            {
                posHoriz += 0.1f;
                posHorizInit += 0.1f;
            }

            //Angle Left/Right
            if (Input.GetKeyDown("q"))
            {
                angleDegHoriz -= 0.1f;
            }

            if (Input.GetKeyDown("e"))
            {
                angleDegHoriz += 0.1f;
            }

            //Angle Up/Down
            if (Input.GetKeyDown("w"))
            {
                angleDegVert -= 0.1f;
            }

            if (Input.GetKeyDown("s"))
            {
                angleDegVert += 0.1f;
            }

            //Restrictions on angle
            if (angleDegVert > 0.0f)
            {
                angleDegVert = 0.0f;
            }

            if (angleDegVert < -0.5f)
            {
                angleDegVert = -0.5f;
            }

            if (angleDegHoriz > 0.5f)
            {
                angleDegHoriz = 0.5f;
            }

            if (angleDegHoriz < -0.5f)
            {
                angleDegHoriz = -0.5f;
            }
        }
        else //If simulation is active
        {
            //Start tracking time
            if(!timeStarted)
            {
                startTime = Time.time;
                timeStarted = true;
                currentTime = startTime;
            }
            else //Update time
            {
                currentTime = Time.time - startTime;
            }

            //Update position of ball
            posDepth = (velocity * Mathf.Cos(-((angleDegVert) * 90) * Mathf.PI / 180) * Mathf.Cos(((angleDegHoriz) * 90) * Mathf.PI/180) * currentTime) - 14.5f;
            
            
            posHoriz = (velocity * Mathf.Cos(-((angleDegVert) * 90) * Mathf.PI / 180) * Mathf.Sin(((angleDegHoriz) * 90) * Mathf.PI / 180) * currentTime) + posHorizInit;


            posVert = velocity * Mathf.Sin(-((angleDegVert) * 90) * Mathf.PI / 180) * currentTime - (9.81f * currentTime * currentTime)/2;

            //Prevent ball from falling through floor
            if (posVert < 0)
            {
                posVert = 0;
            }
                
        }

        //Angle Debug
        //Debug.Log((-((angleDegHoriz) * 90) * Mathf.PI / 180) + " , " + (((angleDegVert) * 90) * Mathf.PI / 180));

        //Activate Ball
        if (Input.GetKeyDown("space"))
        {
            isActivated = true;
        }

        //Reset Scene
        if (Input.GetKeyDown("r"))
        {
            ResetBall();
        }

        //Update position of ball
        transform.position = new Vector3(posHoriz, posVert, posDepth);
        //transform.rotation = new Quaternion(angleDegVert, angleDegHoriz, 0.0f, 1);

    }

    // Reset ball 
    void ResetBall()
    {
        //Default Ball Position
        posHoriz = 0.0f;
        posHorizInit = 0.0f;
        posVert = 1.0f;
        posDepth = -14.5f;

        //Default ball aim
        angleDegVert = 0.0f;
        angleDegHoriz = 0.0f;

        //Reset time/activated variables
        isActivated = false;
        timeStarted = false;
    }
}
