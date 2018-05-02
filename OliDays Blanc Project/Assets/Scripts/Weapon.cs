using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    bool mouseLeft, canShoot;
    Vector3 mousePos, mouseVector;
    public GameObject weapon, weaponTip;
    public GameObject player;
    float lastShot = 0, timeBetweenShots = .7f;
    public GameObject bulletPrefab;
    // Use this for initialization
    void Start () {
        GetMouseInput();
    }
	
	// Update is called once per frame
	void Update () {
        GetMouseInput();
        Animation();
        Shooting();
    }

    void GetMouseInput()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position of cursor in world
        mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - new Vector3(959, 0, 457);
        print(mousePos);
        mousePos.y = player.transform.position.y; //keep the z position consistant, since we're in 2d
        mouseVector = (mousePos); //normalized vector from player pointing to cursor
        mouseLeft = Input.GetMouseButton(0); //check left mouse button
    }

    void Animation()
    {
        float gunAngle = -1 * Mathf.Atan2(mouseVector.z, mouseVector.x) * Mathf.Rad2Deg; //find angle in degrees from player to cursor
        weapon.transform.rotation = Quaternion.AngleAxis(gunAngle, new Vector3 (0, 1, 0)); //rotate gun sprite around that angle
    }
    void Shooting()
    {
        canShoot = (lastShot + timeBetweenShots < Time.time);
        if (mouseLeft && canShoot)
        { //shoot if the mouse button is held and its been enough time since last shot
            Vector3 spawnPos = weaponTip.transform.position; //position of the tip of the gun, a transform that is a child of rotating gun
            Quaternion spawnRot = Quaternion.identity; //no rotation, bullets here are round
            Projectile bul = Instantiate(bulletPrefab, spawnPos, spawnRot).GetComponent<Projectile>();//spawn bullet and capture it's script
            Vector3 direction = new Vector3(mousePos.z, 0, -mousePos.x);
            bul.Setup(direction); //give the bullet a direction to fly
            lastShot = Time.time; //used to check next time this is called
        }
    }
}
