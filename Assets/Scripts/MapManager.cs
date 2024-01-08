using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MapManager : MonoBehaviour
{
    public GameObject Ground;
    public GameObject HorizontalHedgeClosed;
    public GameObject HorizontalHedgeOpen;
    public GameObject VerticalHedgeClosed;
    public GameObject VerticalHedgeOpen;

    public GameObject[,] Screens = new GameObject[6, 6];
    public bool[,] VerticalWalls = new bool[9, 8];
    public bool[,] HorizontalWalls = new bool[8, 9];

    // Start is called before the first frame update
    void Start()
    {
        crawler();

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Instantiate(Ground, new Vector3(i * 16, j * 9, 0), Quaternion.identity);
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

        buildWalls();
    }

    void crawler()
    {
        bool allConnected = false;

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
                bool open = HorizontalWalls[i + 1, j + 1];

                if (open == true)
                {
                    Instantiate(HorizontalHedgeOpen, new Vector3(i * 16 + 8, j * 9, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(HorizontalHedgeClosed, new Vector3(i * 16 + 8, j * 9, 0), Quaternion.identity);
                }
            }
        }

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                bool open = VerticalWalls[i + 1, j + 1];

                if (open == true)
                {
                    Instantiate(VerticalHedgeOpen, new Vector3(i * 16, j * 9 + 4.5f, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(VerticalHedgeClosed, new Vector3(i * 16, j * 9 + 4.5f, 0), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
