using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody player;
    public int speed;
    private int dreams = 0;
    public int Dreams
    {
        get
        {
            return dreams;
        }
        set
        {
            dreams = value;
        }
    }
    private void FixedUpdate()
    {
        
        if (Input.GetKey("d"))
        {
            //player.AddForce(speed * 10, 0, 0);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("z"))
        {
            //player.AddForce(0, 0, speed * 10);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("q"))
        {
            //player.AddForce(-speed * 10, 0, 0);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            //player.AddForce(0, 0, -speed * 10);
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Dreams : " + Dreams);
    }

}
