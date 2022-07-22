using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{

    public GameObject player;
    private Vector3 playerPosition;
    public int pixelDistToDetect = 20;
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool push = false;
    private Vector2 startingPosition, swipeChange;

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            push = true;
            startingPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            push = false;
            Reset();
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                push = true;
                startingPosition = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                push = false;
                Reset();
            }
        }


        //Calculate the distance
        swipeChange = Vector2.zero;
        if (push)
        {
            if (Input.touches.Length < 0)
                swipeChange = Input.touches[0].position - startingPosition;
            else if (Input.GetMouseButton(0))
                swipeChange = (Vector2)Input.mousePosition - startingPosition;
        }

        //Did we cross the distance?
        if (swipeChange.magnitude > pixelDistToDetect)
        {
            //Which direction?
            float x = swipeChange.x;
            float y = swipeChange.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }

        if (swipeLeft)
        {
            playerPosition = player.transform.position;

            if (playerPosition.x == 0)
            {
                playerPosition.x = -1;
            }
            else if (playerPosition.x == 1)
            {
                playerPosition.x = 0;

            }
            player.transform.position = playerPosition;
            swipeLeft = false;
        }

        if (swipeRight)
        {
            playerPosition = player.transform.position;
            if (playerPosition.x == 0)
            {
                playerPosition.x = 1;
            }
            else if (playerPosition.x == -1)
            {

                playerPosition.x = 0;

            }
            player.transform.position = playerPosition;
        }
        swipeRight = false;
    }

    private void Reset()
    {
        startingPosition = swipeChange = Vector2.zero;
        push = false;
    }
}