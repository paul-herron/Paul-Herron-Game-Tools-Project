using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement2 : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float rotSpeed = 100;

    private bool isWandering = false;
    private bool rotLeft = false;
    private bool rotRight = false;
    private bool isMoving = false;

    private void Update()
    {
           if (isWandering == false)
            {
                StartCoroutine(Wander());
            }
        if (rotLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (rotRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isMoving == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }


    IEnumerator Wander()
    {
        //DECIDES WHICH DIRECTION THE ENEMY TURNS, AND FOR HOW LONG IT ROTATES
        int rotTime = UnityEngine.Random.Range(1, 3);
        float rotWait = 0.1f; //UnityEngine.Random.Range(1, 4);
        int rotLOR = UnityEngine.Random.Range(1, 2);
        float moveWait = 0.1f; //UnityEngine.Random.Range(1, 4);
        int moveTime = UnityEngine.Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(moveWait);
        isMoving = true;
        yield return new WaitForSeconds(moveTime);
        isMoving = false;
        yield return new WaitForSeconds(rotWait);
        if (rotLOR == 1)
        {
            rotLeft = true;
            yield return new WaitForSeconds(rotTime);
            rotLeft = false;
        }
        if (rotLOR == 2)
        {
            rotRight = true;
            yield return new WaitForSeconds(rotTime);
            rotRight = false;
        }

        isWandering = false;
    }

}
