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
    public bool[,] VerticalWalls = new bool[5, 6];
    public bool[,] HorizontalWalls = new bool[6, 5];

    // Start is called before the first frame update
    void Start()
    {
        crawler();

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



        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                int pick = Random.Range(0, 2);

                if (pick == 1)
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
                int pick = Random.Range(0, 2);

                if (pick == 1)
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

    void crawler()
    {
        bool allConnected = false;

        bool[,] connected = new bool[6, 6];
        connected[3, 1] = true;



        /*while (allConnected == false)
        {
            
        }*/
    }

    void setWalls(int x, int y)
    {
        bool bottomWall;
        bool leftWall;
        bool rightWall;
        bool topWall;

        // Check walls
        if (Walls[x, y] == true)
        {
            bottomWall = true;
        }
        else
        {
            bottomWall = false;
        }

        if (Walls[x, y] == true)
        {
            bottomWall = true;
        }
        else
        {
            bottomWall = false;
        }

        if (Walls[x, y] == true)
        {
            bottomWall = true;
        }
        else
        {
            bottomWall = false;
        }

        if (Walls[x, y] == true)
        {
            bottomWall = true;
        }
        else
        {
            bottomWall = false;
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


    // Update is called once per frame
    void Update()
    {

    }
}