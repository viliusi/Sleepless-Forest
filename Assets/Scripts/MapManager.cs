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

    public GameObject[,] Screens = new GameObject[7, 7];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Screens[i, j] = Instantiate(Ground, new Vector3(i * 16, j * 9, 0), Quaternion.identity);
            }
        }

        Crawler();

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

    void Crawler()
    {
        bool allConnected = false;
        int[] currentPos = new int[2] { 3, 2 };

        bool[,] connected = new bool[7, 7];
        connected[3, 1] = true;

        while (allConnected == false)
        {
            GameObject screen = Screens[currentPos[0], currentPos[1]];
            Screen script = screen.GetComponent<Screen>();

            if (script.accesible() == true)
            {
                print("Accesible");
            }

            // Test if they're all connected

            allConnected = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}