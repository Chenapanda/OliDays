using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 dir, nextDir;
    float speed, startSpeed = 7.5f;
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
}