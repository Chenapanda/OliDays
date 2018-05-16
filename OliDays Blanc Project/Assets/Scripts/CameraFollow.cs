using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Rigidbody player;
    public int Height;

    void Start()
    {

    }

    private void LateUpdate()
    {
        transform.localPosition = player.transform.localPosition + new Vector3(0, Height, 0);
    }
    
}
