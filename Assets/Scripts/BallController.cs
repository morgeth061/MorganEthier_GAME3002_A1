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

    [SerializeField]
    bool isActivated;

    float velocity;

    bool timeStarted;
    float startTime;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        //init variables

        //Default ball aim
        posHoriz = 0.0f;
        posVert = 1.0f;
        posDepth = -14.5f;
        angleDegVert = 0.0f;
        angleDegHoriz = 0.0f;

        velocity = 10.0f;

        isActivated = false;
        timeStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(!isActivated)
        {
            if (angleDegVert > 0.0f)
            {
                angleDegVert = 0.0f;
            }

            if(angleDegVert < -0.5f)
            {
                angleDegVert = -0.5f;
            }

            if (Input.GetKeyDown("a"))
            {
                posHoriz -= 0.1f;
            }

            if (Input.GetKeyDown("d"))
            {
                posHoriz += 0.1f;
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

            if (angleDegVert > 0.0f)
            {
                angleDegVert = 0.0f;
            }

            
        }
        else
        {
            if(!timeStarted)
            {
                startTime = Time.time;
                timeStarted = true;
                currentTime = startTime;
            }
            else
            {
                currentTime = Time.time - startTime;
            }

            

            posDepth = (velocity * Mathf.Cos(-(angleDegVert) * 90) * currentTime) - 14.5f;
            posVert = velocity * Mathf.Sin(-(angleDegVert) * 90) * currentTime - (9.81f * currentTime * currentTime)/2;

            

            if (posVert < 0)
                posVert = 0;
        }

        Debug.Log((-(angleDegVert) * 90));

        if (Input.GetKeyDown("space"))
        {
            isActivated = true;
        }

        if (Input.GetKeyDown("r"))
        {
            ResetBall();
        }

        transform.position = new Vector3(posHoriz, posVert, posDepth);
        transform.rotation = new Quaternion(angleDegVert, angleDegHoriz, 0.0f, 1);

    }

    // Reset ball 
    void ResetBall()
    {
        //Default ball aim
        posHoriz = 0.0f;
        posVert = 1.0f;
        posDepth = -14.5f;
        angleDegVert = 0.0f;
        angleDegHoriz = 0.0f;
        isActivated = false;
        timeStarted = false;
    }

    // Shoot ball
    void ShootBall()
    {
        //Set Position
    }
}
