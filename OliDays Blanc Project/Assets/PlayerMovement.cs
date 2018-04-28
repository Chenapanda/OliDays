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
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }

}
