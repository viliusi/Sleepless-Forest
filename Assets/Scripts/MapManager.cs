using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MapManager : MonoBehaviour
{
    public List<GameObject> Maps = new List<GameObject>();
    public GameObject HorizontalHedgeClosed;
    public GameObject HorizontalHedgeOpen;
    public GameObject VerticalHedgeClosed;
    public GameObject VerticalHedgeOpen;

    public GameObject[,] Screens = new GameObject[6, 6];
    public bool[,] VerticalWalls = new bool[9, 8];
    public bool[,] HorizontalWalls = new bool[8, 9];

    public List<GameObject> AllWalls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        crawler();

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i == 3)
                {
                    if (j == 1)
                    {
                        Instantiate(Maps[0], new Vector3(i * 16, j * 9, 0.01f), Quaternion.identity);
                    }
                    else
                    {
                        int random = Random.Range(0, Maps.Count);

                        GameObject map = Maps[random];

                        Instantiate(map, new Vector3(i * 16, j * 9, 0.01f), Quaternion.identity);
                    }
                }
                else
                {
                    int random = Random.Range(0, Maps.Count);

                    GameObject map = Maps[random];

                    Instantiate(map, new Vector3(i * 16, j * 9, 0.01f), Quaternion.identity);
                }
            }
        }

        for (int i = 0; i < 7; i++)
        {
            Instantiate(HorizontalHedgeClosed, new Vector3(-7.5f, i * 9, 0), Quaternion.identity);
        }

        for (int i = 0; i < 7; i++)
        {
            Instantiate(HorizontalHedgeClosed, new Vector3(103.5f, i * 9, 0), Quaternion.identity);
        }

        for (int i = 0; i < 7; i++)
        {
            Instantiate(VerticalHedgeClosed, new Vector3(i * 16, -4, 0), Quaternion.identity);
        }

        for (int i = 0; i < 7; i++)
        {
            Instantiate(VerticalHedgeClosed, new Vector3(i * 16, 58, 0), Quaternion.identity);
        }
    }

    void crawler()
    {
        Vector2 room = new Vector2(3, 1);

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                room = new Vector2(i, j);

                // chance time
                int doorAmount = chanceTime();

                // choose which passages to change
                setWalls(doorAmount, room);
            }
        }

        buildWalls();
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
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
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

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
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
        if(Input.GetKey(KeyCode.R))
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    HorizontalWalls[i + 1, j + 1] = false;
                }
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    VerticalWalls[i + 1, j + 1] = false;
                }
            }

            foreach (var wall in AllWalls)
            {
                Destroy(wall);
            }

            crawler();

            buildWalls();
        }
    }
}
