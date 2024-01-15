using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool IsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("PlayerTag").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
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
        if (IsActive)
        {
            StartCoroutine(MoveEnemy(movement));
        }
    }

    IEnumerator MoveEnemy(Vector2 direction)
    {
        //temporary: Waits for two seconds before movement is activated, gives player a chance to act first
        yield return new WaitForSeconds(1f);
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
