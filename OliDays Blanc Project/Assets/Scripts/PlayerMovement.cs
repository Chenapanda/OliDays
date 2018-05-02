using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody player;
    public int speed;
    private void FixedUpdate()
    {
        
        if (Input.GetKey("z"))
        {
            //player.AddForce(speed, 0, 0);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("q"))
        {
            //player.AddForce(0, 0, speed);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            //player.AddForce(-speed, 0, 0);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            //player.AddForce(0, 0, -speed);
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }

}
