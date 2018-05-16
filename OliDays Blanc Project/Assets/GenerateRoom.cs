using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour {

    public Texture2D[] patterns;
    public ColorToPrefabs[] colorMappings;
	// Use this for initialization
	void Start ()
    {

	}
	
	public void GenerateRooms(Room room)
    {
        float x = room.gridPos[0];
        float y = room.gridPos[1];
        Texture2D thisroom = patterns[Random.Range(0, patterns.Length)];
        int length = thisroom.width;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                GenerateTile(i, j, thisroom, room);
            }
        }
    }
    public void GenerateTile(int i, int j, Texture2D thisroom, Room room)
    {
        Color pixelColor = thisroom.GetPixel(i, j);

        if (pixelColor.a == 0)
        {
            return; //pixel is transparent
        }

        foreach (ColorToPrefabs colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(room.gridPos.y * 9 - 3.5f + i, 0, room.gridPos.x * 9 - 3.5f + j);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
