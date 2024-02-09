using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        GameManager gameManager = gameManagerObject.GetComponent<GameManager>();

        gameManager.Volume = this;
    }
}
