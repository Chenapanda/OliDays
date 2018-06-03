using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 dir;
    float speed, startSpeed = 7.5f;

    
    
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
        if (other.gameObject.tag == "Dreams")
        {
            return;
        }
        if (other.gameObject.tag == "enemy")
        {
            float dammage = GameObject.Find("Player").GetComponent<PlayerMovement>().Dammage;
            other.GetComponent<enemy>().ishit(dammage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}