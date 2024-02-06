using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int Height;
    public int Width;

    public int PlayerStartHeight;
    public int PlayerStartWidth;

    public List<GameObject> Maps = new List<GameObject>();
    public GameObject HorizontalHedgeClosed;
    public GameObject HorizontalHedgeOpen;
    public GameObject VerticalHedgeClosed;
    public GameObject VerticalHedgeOpen;

    public bool[,] VerticalWalls;
    public bool[,] HorizontalWalls;

    public List<GameObject> AllWalls = new List<GameObject>();
    public List<GameObject> AllScreens = new List<GameObject>();

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
    }

    private void setUp()
    {
        // set up wall arrays based of height and width
        VerticalWalls = new bool[Width + 2, Height + 1];
        HorizontalWalls = new bool[Width + 1, Height + 2];
    }

    void build()
    {
        int endX = PlayerStartWidth;
        int endY = PlayerStartHeight;

        while (endX == PlayerStartWidth && endY == PlayerStartHeight)
        {
            endX = Random.Range(0, Width);
            endY = Random.Range(0, Height);
        }

        AllScreens.Add(Instantiate(Maps[1], new Vector3(endX * 16, endY * 9, 0.01f), Quaternion.identity));

        for (int i = 0; i < Height + 1; i++)
        {
            for (int j = 0; j < Width + 1; j++)
            {
                if (i == PlayerStartWidth)
                {
                    if (j == PlayerStartHeight)
                    {
                        AllScreens.Add(Instantiate(Maps[0], new Vector3(i * 16, j * 9, 0.01f), Quaternion.identity));
                    }
                    else
                    {
                        if (i == endX && j == endY)
                        {

                        }
                        else
                        {
                            int random = Random.Range(2, Maps.Count);

                            GameObject map = Maps[random];

                            AllScreens.Add(Instantiate(map, new Vector3(i * 16, j * 9, 0.01f), Quaternion.identity));
                        }
                    }
                }
                else
                {
                    if (i == endX && j == endY)
                    {

                    }
                    else
                    {
                        int random = Random.Range(2, Maps.Count);

                        GameObject map = Maps[random];

                        AllScreens.Add(Instantiate(map, new Vector3(i * 16, j * 9, 0.01f), Quaternion.identity));
                    }
                }
            }
        }

        for (int i = 0; i < Width; i++)
        {
            AllWalls.Add(Instantiate(HorizontalHedgeClosed, new Vector3(-7.5f, i * 9, 0), Quaternion.identity));
        }

        for (int i = 0; i < Width; i++)
        {
            AllWalls.Add(Instantiate(HorizontalHedgeClosed, new Vector3(103.5f, i * 9, 0), Quaternion.identity));
        }

        for (int i = 0; i < Height; i++)
        {
            AllWalls.Add(Instantiate(VerticalHedgeClosed, new Vector3(i * 16, -4, 0), Quaternion.identity));
        }

        for (int i = 0; i < Height; i++)
        {
            AllWalls.Add(Instantiate(VerticalHedgeClosed, new Vector3(i * 16, 58, 0), Quaternion.identity));
        }
    }

    void crawler()
    {
        Vector2 room = new Vector2(PlayerStartWidth, PlayerStartHeight);

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                room = new Vector2(i, j);

                // chance time
                int doorAmount = chanceTime();

                // choose which passages to change
                setWalls(doorAmount, room);
            }
        }

        buildWalls();

        build();
    }

    int chanceTime()
    {
        int pick = Random.Range(0, 10);

        if (pick <= 5)
        {
            return 1;
        }
        else if (pick <= 9)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

    void setWalls(int number, Vector2 room)
    {
        for (int i = 0; i < number; i++)
        {
            bool retry = true;

            int attempts = 0;

            while (retry == true)
            {
                attempts++;

                int pick = Random.Range(0, 3);

                switch (pick)
                {
                    case 0:
                        if (HorizontalWalls[(int)room.x + 1, (int)room.y + 1] == false)
                        {
                            HorizontalWalls[(int)room.x + 1, (int)room.y + 1] = true;
                            retry = false;
                        }

                        break;
                    case 1:
                        if (VerticalWalls[(int)room.x + 1, (int)room.y + 1] == false)
                        {
                            VerticalWalls[(int)room.x + 1, (int)room.y + 1] = true;
                            retry = false;
                        }
                        break;
                    case 2:
                        if (VerticalWalls[(int)room.x + 1, (int)room.y] == false)
                        {
                            VerticalWalls[(int)room.x + 1, (int)room.y] = true;
                            retry = false;
                        }
                        break;
                    default:
                        if (HorizontalWalls[(int)room.x + 1, (int)room.y] == false)
                        {
                            HorizontalWalls[(int)room.x + 1, (int)room.y] = true;
                            retry = false;
                        }
                        break;

                }

                if (attempts > 10)
                {
                    retry = false;
                }
            }
        }
    }

    void buildWalls()
    {
        int horizontalWidth = HorizontalWalls.GetLength(0);
        int horizontalHeight = HorizontalWalls.GetLength(1);

        for (int i = 0; i < horizontalWidth - 1; i++)
        {
            for (int j = 0; j < horizontalHeight - 1; j++)
            {
                GameObject wall;

                bool open = HorizontalWalls[i + 1, j + 1];

                if (open == true)
                {
                    wall = Instantiate(HorizontalHedgeOpen, new Vector3(i * 16 + 8, j * 9, 0), Quaternion.identity);
                }
                else
                {
                    wall = Instantiate(HorizontalHedgeClosed, new Vector3(i * 16 + 8, j * 9, 0), Quaternion.identity);
                }

                AllWalls.Add(wall);
            }
        }

        int verticalWidth = VerticalWalls.GetLength(0);
        int verticalHeight = VerticalWalls.GetLength(1);

        for (int i = 0; i < verticalWidth - 1; i++)
        {
            for (int j = 0; j < verticalHeight - 1; j++)
            {
                GameObject wall;

                bool open = VerticalWalls[i + 1, j + 1];

                if (open == true)
                {
                    wall = Instantiate(VerticalHedgeOpen, new Vector3(i * 16, j * 9 + 4.5f, 0), Quaternion.identity);
                }
                else
                {
                    wall = Instantiate(VerticalHedgeClosed, new Vector3(i * 16, j * 9 + 4.5f, 0), Quaternion.identity);
                }

                AllWalls.Add(wall);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        int horizontalWidth = HorizontalWalls.GetLength(0);
        int horizontalHeight = HorizontalWalls.GetLength(1);

        for (int i = 0; i < horizontalWidth - 1; i++)
        {
            for (int j = 0; j < horizontalHeight - 1; j++)
            {
                HorizontalWalls[i + 1, j + 1] = false;
            }
        }

        int verticalWidth = VerticalWalls.GetLength(0);
        int verticalHeight = VerticalWalls.GetLength(1);

        for (int i = 0; i < verticalWidth - 1; i++)
        {
            for (int j = 0; j < verticalHeight - 1; j++)
            {
                VerticalWalls[i + 1, j + 1] = false;
            }
        }

        foreach (var wall in AllWalls)
        {
            Destroy(wall);
        }

        foreach (var screen in AllScreens)
        {
            Destroy(screen);
        }

        crawler();

        Player.transform.position = new Vector3(48, 7, -1);
    }
}
