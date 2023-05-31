using UnityEngine;
using System.Collections.Generic;

public class CrearMapas : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public GameObject tilePrefab;
    public GameObject wallPrefab;

    public int numRooms;
    public int roomMinWidth;
    public int roomMaxWidth;
    public int roomMinHeight;
    public int roomMaxHeight;

    private GameObject[,] tiles;
    private List<GameObject> walls;
    private List<Rect> rooms;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        tiles = new GameObject[mapWidth, mapHeight];
        walls = new List<GameObject>();
        rooms = new List<Rect>();

        // Generate rooms
        for (int i = 0; i < numRooms; i++)
        {
            int roomWidth = Random.Range(roomMinWidth, roomMaxWidth);
            int roomHeight = Random.Range(roomMinHeight, roomMaxHeight);
            int roomX = Random.Range(10, mapWidth - roomWidth - 10);
            int roomY = Random.Range(10, mapHeight - roomHeight - 10);
            Rect room = new Rect(roomX, roomY, roomWidth, roomHeight);
            bool overlaps = false;

            foreach (Rect otherRoom in rooms)
            {
                if (room.Overlaps(otherRoom))
                {
                    overlaps = true;
                    break;
                }
            }

            if (!overlaps)
            {
                rooms.Add(room);
                for (int x = roomX; x < roomX + roomWidth; x++)
                {
                    for (int y = roomY; y < roomY + roomHeight; y++)
                    {
                        GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                        tiles[x, y] = tile;

                        if (x == roomX || x == roomX + roomWidth - 1 || y == roomY || y == roomY + roomHeight - 1)
                        {
                            GameObject wall = Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                            walls.Add(wall);
                        }
                    }
                }
            }
        }

    }
}



