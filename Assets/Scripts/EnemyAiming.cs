using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : MonoBehaviour
{
    public Camera cam;
    public Transform player;

    Vector2 mousePos;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerTag").transform;

        cam = (Camera) GameObject.FindObjectOfType(typeof(Camera));
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 lookDir = player.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }
}

