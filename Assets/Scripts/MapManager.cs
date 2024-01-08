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
    public bool[,] VerticalWalls = new bool[7, 6];
    public bool[,] HorizontalWalls = new bool[6, 7];

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

        /*bool[,] connected = new bool[6, 6];
        connected[3, 1] = true;*/

        while (allConnected == false)
        {
            // get room
            Vector2 room = new Vector2(3, 1);

            // chance time
            int doorAmount = chanceTime();

            // choose which passages to change
            setWalls(doorAmount, room);

            // if the door is not already opened, set to open


            allConnected = true;
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
                        print("Case 0");
                        if (HorizontalWalls[(int)room.x, (int)room.y] == false)
                        {
                            HorizontalWalls[(int)room.x, (int)room.y] = true;
                            retry = false;
                        }

                        break;
                    case 1:
                        print("Case 1");
                        if (VerticalWalls[(int)room.x, (int)room.y] == false)
                        {
                            VerticalWalls[(int)room.x, (int)room.y] = true;
                            retry = false;
                        }
                        break;
                    case 2:
                        print("Case 2");
                        if (VerticalWalls[(int)room.x, (int)room.y - 1] == false)
                        {
                            VerticalWalls[(int)room.x, (int)room.y - 1] = true;
                            retry = false;
                        }
                        break;
                    default:
                        print("Case default");
                        if (HorizontalWalls[(int)room.x, (int)room.y - 1] == false)
                        {
                            HorizontalWalls[(int)room.x, (int)room.y - 1] = true;
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
                bool open = HorizontalWalls[i, j];

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
                bool open = VerticalWalls[i, j];

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
