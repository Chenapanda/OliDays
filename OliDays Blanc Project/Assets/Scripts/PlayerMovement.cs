using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject self;
    public Rigidbody player;
    public int speed;
    public Texture2D Staff;

    private float dammage = 5f;
    public float Dammage
    {
        get
        {
            return dammage;
        }
        set
        {
            dammage = value;
        }
    }

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
        GUI.contentColor = Color.magenta;
        GUI.Label(new Rect(20, 20, 100, 20), "Dreams : " + Dreams);
        //displays dammage
        Rect posDammage = new Rect(20, 50, 40, 40);
        GUI.Label(posDammage, Staff);
        Rect posDammage2 = new Rect(70, 60, 70, 70);
        GUI.Label(posDammage2, dammage.ToString());
    }

}
