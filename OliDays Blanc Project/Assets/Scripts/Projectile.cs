using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 dir, nextDir;
    float speed, startSpeed = 5f;
    bool recalling, disappearing;
    Transform recallTarget;
    public void Setup(Vector3 _dir)
    {
        dir = _dir; //passed in from player
        speed = startSpeed; //start moving
    }
    void FixedUpdate()
    {
        Move(); //move the bullet
        CheckDisappear(); //get rid of bullet after it stops moving
    }
    void Move()
    {
        Vector3 tempPos = transform.position; //capture current position
        tempPos += dir * speed * Time.fixedDeltaTime; //find new position
        transform.position = tempPos; //update position
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.GetComponent<enemy>().ishit(5);
        }
        Destroy(gameObject);
    }
    void CheckDisappear()
    {
        if (speed == 0 && !disappearing)
        { //disappear and destroy when stopped
            disappearing = true; //so we dont continuelly call the coroutine
            StartCoroutine(Disappear());
        }
    }
    IEnumerator Disappear()
    {
        float curAlpha = 1; //start at full alpha
        float disSpeed = 3f; //take 1/3 seconds to disappear
        do
        {
            curAlpha -= disSpeed * Time.deltaTime; //find new alpha
            yield return null;
        } while (curAlpha > 0); //end when the bullet is transparent
        Destroy(gameObject); //get rid of bullet now that it can't be seen
    }
}