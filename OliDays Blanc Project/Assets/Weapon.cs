using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    bool mouseLeft, canShoot;
    Vector3 mousePos, mouseVector;
    public Transform weapon, weaponTip;
    public Transform player;

	// Use this for initialization
	void Start () {
        GetMouseInput();
    }
	
	// Update is called once per frame
	void Update () {
        GetMouseInput();
        Animation();

    }
    void GetMouseInput()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position of cursor in world
        mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - new Vector3(450, 0, 367); ;
        mousePos.y = player.position.y; //keep the z position consistant, since we're in 2d
        mouseVector = (mousePos); //normalized vector from player pointing to cursor
        mouseLeft = Input.GetMouseButton(0); //check left mouse button
    }

    void Animation()
    {
        float gunAngle = -1 * Mathf.Atan2(mouseVector.z, mouseVector.x) * Mathf.Rad2Deg; //find angle in degrees from player to cursor
        weapon.rotation = Quaternion.AngleAxis(gunAngle, new Vector3 (0, 1, 0)); //rotate gun sprite around that angle
    }
}
