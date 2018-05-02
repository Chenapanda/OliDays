using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{ // ce script permet d'avoir tjrs une trace de notre joueur

    public static PlayManager instance;

    void Awake()
    {
        instance = this;
    }
    public GameObject player; // référence à notre perso

}

