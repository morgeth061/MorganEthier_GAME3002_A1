//***********************************
// ArrowController.cs
// - Morgan Ethier
// - Created for GAME3002_A1
// - Controller script for aiming arrow
//***********************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    [SerializeField]
    float angleHoriz;

    [SerializeField]
    float angleVert;

    [SerializeField]
    float posHoriz;

    [SerializeField]
    bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        angleHoriz = 0.0f;
        angleVert = 0.0f;
        posHoriz = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isActivated)
        {
            //Movement Left/Right
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
                angleHoriz -= 0.1f;
            }

            if (Input.GetKeyDown("e"))
            {
                angleHoriz += 0.1f;
            }

            //Angle Up/Down
            if (Input.GetKeyDown("w"))
            {
                angleVert -= 0.1f;
            }

            if (Input.GetKeyDown("s"))
            {
                angleVert += 0.1f;
            }

            // Prevent arrow from moving further than ball is able to
            if (angleVert > 0.0f)
            {
                angleVert = 0.0f;
            }
            if (angleVert < -0.5f)
            {
                angleVert = -0.5f;
            }

            if (angleHoriz > 0.5f)
            {        
                angleHoriz = 0.5f;
            }        
            if (angleHoriz < -0.5f)
            {        
                angleHoriz = -0.5f;
            }

            if (Input.GetKeyDown("space"))
            {
                isActivated = true;
            }

            //Update position of arrow
            transform.position = new Vector3(posHoriz, 1, -14.5f);
            transform.rotation = new Quaternion(angleVert, angleHoriz, 0.0f, 1);
        }
        else //if arrow not active, teleport out of range
        {
            transform.position = new Vector3(0, -10, 0);
        }

        // Reset arrow position
        if (Input.GetKeyDown("r"))
        {
            Reset();
        }

    }

    // Resets arrow position
    void Reset()
    {
        //Default position
        posHoriz = 0.0f;
        angleVert = 0.0f;
        angleHoriz = 0.0f;
        isActivated = false;

        transform.position = new Vector3(0.0f, 1.0f, -14.5f);
        transform.rotation = new Quaternion(angleVert, angleHoriz, 0.0f, 1);
    }
}
