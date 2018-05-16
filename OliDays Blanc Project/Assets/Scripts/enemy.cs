using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public GameObject dream;
    public GameObject me;
    public Rigidbody self;
    private int health = 10;
    private int loot = 50;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ishit(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            if (Random.Range(0, 100) < loot)
            {
                Instantiate(dream, transform.position, new Quaternion(0, 0, 0, 0));
            }
            Destroy(gameObject);
        }
    }
}
