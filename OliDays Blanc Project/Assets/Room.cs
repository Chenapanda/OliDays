using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{

    public Vector2 gridPos;
    public int type;
    public bool openTop, openBot, openLeft, openRight;
    public Room(Vector2 gridPos, int type)
    {
        this.gridPos = gridPos;
        this.type = type;
    }
}
