using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    float posHoriz;

    [SerializeField]
    float angleDegVert;

    [SerializeField]
    bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        //init variables

        //Default ball aim
        posHoriz = 0.0f;
        angleDegVert = 0.0f;
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(!isActivated)
        {
            if (angleDegVert < 0.0f)
            {
                angleDegVert = 0.0f;
            }

            if (Input.GetKeyDown("a"))
            {
                posHoriz -= 0.1f;
            }

            if (Input.GetKeyDown("d"))
            {
                posHoriz += 0.1f;
            }

            transform.position = new Vector3(posHoriz, 0, -15.0f);
        }

        if (Input.GetKeyDown("space"))
        {
            isActivated = true;
        }

        if (Input.GetKeyDown("r"))
        {
            ResetBall();
        }

    }

    // Reset ball 
    void ResetBall()
    {
        //Default ball aim
        posHoriz = 0.0f;
        angleDegVert = 0.0f;
        isActivated = false;
    }

    // Shoot ball
    void ShootBall()
    {
        //Set Position
    }
}
