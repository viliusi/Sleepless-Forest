using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        transform.position = Player.position;
        
        if (Input.GetButtonDown("Fire2"))
        {
            Hitting();
        }
    }

    void Hitting()
    {
        
    }
}
