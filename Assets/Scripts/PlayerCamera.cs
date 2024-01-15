using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera Camera;
    public float Speed;
    public Vector3 CurrentRoom;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            CurrentRoom = other.transform.position;
        }
    }

    public void Update()
    {
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, CurrentRoom + new Vector3(0, 0, -10f), Speed * Time.deltaTime);
    }
}
