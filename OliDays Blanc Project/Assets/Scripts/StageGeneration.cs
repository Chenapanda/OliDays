using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGeneration : MonoBehaviour {
    public GameObject roomU, roomD, roomL, roomR, roomUD, roomLR, roomUR, roomUL, roomDR, roomDL, roomUDL, roomULR, roomUDR, roomDLR, roomUDLR;
    private Vector2 stageSize = new Vector2 (4, 4);
    Room[,] rooms;
    List<Vector2> occupiedPos = new List<Vector2>();
    private int numberofrooms = 20;
    int gridSizeX, gridSizeY, numberOfRooms;
    public GameObject roomObj;
	
// Use this for initialization
void Start()
{
        numberOfRooms = numberofrooms;
        if (numberOfRooms >= (stageSize.x * 2) * (stageSize.y * 2))
        {
            numberOfRooms = Mathf.RoundToInt((stageSize.x * 2) * (stageSize.y * 2));
        }
        gridSizeX = Mathf.RoundToInt(stageSize.x);
        gridSizeY = Mathf.RoundToInt(stageSize.y);
        CreateRooms();
        SetRoomDoors();
        DrawMap();
}
    void CreateRooms()
    {
        //setup
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 1); //make the starting room at the center of the map
        occupiedPos.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;
        //nombre aléatoires formule
        float randomCompare = 0.2f;
        float randomCompareStart = 0.2f;
        float randomeCompareEnd = 0.01f;
        //add rooms
        for (int i = 0; i < numberOfRooms - 1; i++)
        {
            //Math to determine odds
            float randomPerc = ((float)i) / (((float)numberOfRooms - 1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomeCompareEnd, randomPerc);
            //find a valid pos
            checkPos = NewPosition();
            //test new position
            if (NumberOfNeighbors(checkPos, occupiedPos) > 1 && Random.value > randomCompare)
            {
                int iterations = 0;
                do
                {
                    checkPos = SelectivePosition();
                    iterations += 1;
                } while (NumberOfNeighbors(checkPos, occupiedPos) > 1 && iterations < 100);
                if (iterations >= 50)
                {
                    print("error : could not create with fewer neighbors than : " + NumberOfNeighbors(checkPos, occupiedPos));
                }
                //finitions
                
            }
            rooms[(int) checkPos.x + gridSizeX, (int)checkPos.y + gridSizeY] = new Room(checkPos, 0);
            occupiedPos.Insert(0, checkPos);
        }
    }
    Vector2 NewPosition()
    {
        int x = 0;
        int y = 0;
        Vector2 chekingPos = Vector2.zero;
        do
        {
            int index = Mathf.RoundToInt(Random.value * (occupiedPos.Count - 1));
            x = (int) occupiedPos[index].x;
            y = (int) occupiedPos[index].y;
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (UpDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }

            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            chekingPos = new Vector2(x, y);
        } while (occupiedPos.Contains(chekingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        return chekingPos;
    }
    Vector2 SelectivePosition()
    {
        int index = 0;
        int inc = 0;
        int x = 0;
        int y = 0;
        Vector2 chekingPos = Vector2.zero;
        do
        {
            inc = 0;
            do
            {
                index = Mathf.RoundToInt(Random.value * (occupiedPos.Count - 1));
                inc += 1;
            } while (NumberOfNeighbors(occupiedPos[index], occupiedPos) > 1 && inc < 100);  
            x = (int)occupiedPos[index].x;
            y = (int)occupiedPos[index].y;
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (UpDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }

            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            chekingPos = new Vector2(x, y);
        } while (occupiedPos.Contains(chekingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        if (inc >= 100)
        {
            print("Error : could not find position with only one neighbor");
        }
        return chekingPos;
    }
    int NumberOfNeighbors(Vector2 checkingPos, List<Vector2> usedPositions)
    {
        int neighbors = 0;
        if (usedPositions.Contains(checkingPos + Vector2.right))
        {
            neighbors++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.left))
        {
            neighbors++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.up))
        {
            neighbors++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.down))
        {
            neighbors++;
        }
        return neighbors;
    }
    void SetRoomDoors()
    {
        for (int i = 0; i < ((gridSizeX * 2)); i++)
        {
            for (int j = 0; j < ((gridSizeY * 2)); j++)
            {
                if (rooms[i, j] == null)
                {
                    continue;
                }
                if (j - 1 < 0) //check above
                {
                    rooms[i, j].openTop = false;
                }
                else
                {
                    rooms[i, j].openTop = (rooms[i, j - 1] != null);
                }
                if (j + 1 >= gridSizeY * 2) //check below
                {
                    rooms[i, j].openBot = false;
                }
                else
                {
                    rooms[i, j].openBot = (rooms[i, j + 1] != null);
                }
                if (i - 1 < 0) //check left
                {
                    rooms[i, j].openLeft = false;
                }
                else
                {
                    rooms[i, j].openLeft = (rooms[i - 1, j] != null);
                }
                if (i + 1 >= gridSizeX * 2) //check right
                {
                    rooms[i, j].openRight = false;
                }
                else
                {
                    rooms[i, j].openRight = (rooms[i + 1, j] != null);
                }
            }
        }
    }
    void PickRoomType(Room room)
    {
        if (room.openTop)
        {
            if (room.openBot)
            {
                if (room.openRight)
                {
                    if (room.openLeft)
                    {
                        roomObj = roomUDLR;
                    }
                    else
                    {
                        roomObj = roomUDR;
                    }
                }
                else if (room.openLeft)
                {
                    roomObj = roomUDL;
                }
                else
                {
                    roomObj = roomUD;
                }
            }
            else
            {
                if (room.openRight)
                {
                    if (room.openLeft)
                    {
                        roomObj = roomULR;
                    }

                    else
                    {
                        roomObj = roomUR;
                    }
                }

                else if (room.openLeft)
                    
                    {
                        roomObj = roomUL;
                    }
                    else
                    {
                        roomObj = roomU;
                    }
                }
                return;
            }
            if (room.openBot)
            {
                if (room.openRight)
                {
                    if (room.openLeft)
                    {
                        roomObj = roomDLR;
                    }
                    else
                    {
                        roomObj = roomDR;
                    }
                }
                else if (room.openLeft)
                {
                    roomObj = roomDL;
                
            }
            else
            {
                roomObj = roomD;
            }
            return;
        }
        if (room.openRight)
        {
            if (room.openLeft)
            {
                roomObj = roomLR;
            }
            else
            {
                roomObj = roomR;
            }
        }
        else
        {
            roomObj = roomL;
        }
    }
            
        
    
    void DrawMap()
        {
            foreach (Room room in rooms)
            {
                if (room == null)
                {
                    continue;
                }
            PickRoomType(room);
            Vector3 drawPos = new Vector3(room.gridPos.y, 0, room.gridPos.x);
            drawPos.x *= 9;
            drawPos.z *= 9;
            
            Object.Instantiate(roomObj, drawPos, Quaternion.identity);
            transform.Rotate(0, 90, 0);
            }
        }
        
    
    // Update is called once per frame
    void Update()
    {

    }
}
