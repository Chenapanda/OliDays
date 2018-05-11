﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreams : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerMovement>().Dreams++; //Add 1 dream to the player (in PlayerMovement)
            Destroy(gameObject);
        }
    }
}
