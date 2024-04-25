using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInsomnia : MonoBehaviour
{
    public float insomnia;

    // Start is called before the first frame update
    void Start()
    {
        insomnia = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            insomnia += 0.1f;
            print("Insomnia is" + insomnia);
        }
    }
}
