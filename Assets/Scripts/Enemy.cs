using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool IsActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("PlayerTag").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive == true)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
    }
    private void FixedUpdate()
    {
        if (IsActive == true)
        {
            StartCoroutine(MoveEnemy(movement));
        }
    }

    IEnumerator MoveEnemy(Vector2 direction)
    {
        if (IsActive == true)
        {
            //temporary: Waits for two seconds before movement is activated, gives player a chance to act first
            yield return new WaitForSeconds(1f);
            rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Screen screenComponent = collision.gameObject.GetComponent<Screen>();

        if (screenComponent != null)
        {
            if (!screenComponent.Enemies.Contains(transform.gameObject))
            {
                screenComponent.Enemies.Add(transform.gameObject);
            }
            else
            {
                Debug.Log("GameObject already added to the list.");
            }
        }

        IsActive = false;
    }
}
