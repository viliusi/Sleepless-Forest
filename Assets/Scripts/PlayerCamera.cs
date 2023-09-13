using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera Camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            // fix it, so it's a bit slower
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, other.transform.position + new Vector3(0, 0, -10f), 1f);
        }
    }
}
