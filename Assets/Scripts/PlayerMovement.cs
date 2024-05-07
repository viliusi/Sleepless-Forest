using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class PlayerMovement : MonoBehaviour
{
	public PlayerStats playerStats;
	public Material[] material;
	public Renderer rend;
	public float Speed;
	public float DodgeMultiplier;
	public Image staminaStatus;
	private SpriteRenderer spriteRenderer;


	private Rigidbody2D _rb;
	private Vector3 _lastMovement;
	private Animator animator;

	private bool _coolDown;

	private bool _movementPossible;
	
	public float StunDuration;

	public int bearTrapDamage;

	void Start()
	{
		_coolDown = false;
		_movementPossible = true;
		rend.enabled = true;
		staminaStatus.color = Color.green;
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    void Update()
	{
		if (_movementPossible == true)
		{
			//Basic movement, WASD
			if (Input.GetKey(KeyCode.W))
			{
				//_lastMovement is defined and then used to move the player
				_lastMovement = Vector3.up * Time.deltaTime * Speed;
				transform.Translate(_lastMovement);
			}

			if (Input.GetKey(KeyCode.S))
			{
				_lastMovement = Vector3.down * Time.deltaTime * Speed;
				transform.Translate(_lastMovement);
			}

			if (Input.GetKey(KeyCode.D))
			{
				spriteRenderer.flipX = false;
				_lastMovement = Vector3.right * Time.deltaTime * Speed;
				transform.Translate(_lastMovement);
			}

			if (Input.GetKey(KeyCode.A))
			{
				spriteRenderer.flipX = true;
				_lastMovement = Vector3.left * Time.deltaTime * Speed;
				transform.Translate(_lastMovement);

			}

			//Dodge function, space 
			if (Input.GetKey(KeyCode.Space) && _coolDown == false)
			{
				//_lastMovement is used to allow for dodging in the same
				//direction as the latest movement
				transform.Translate(_lastMovement * DodgeMultiplier);
				staminaStatus.color = Color.black;
				StartCoroutine(Cooldown());
			}
		}
	}

	private IEnumerator Cooldown()
	{
		//Effects of cooldown
		yield return new WaitForSeconds(0.1f);
		_coolDown = true;
		yield return new WaitForSeconds(2);
		_coolDown = false;
		staminaStatus.color = Color.green;
	}

    private IEnumerator Stun(Collider2D bearTrap)
    {
        _movementPossible = false;
        yield return new WaitForSeconds(StunDuration);
        _movementPossible = true;
        Destroy(bearTrap.transform.parent.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TrapTag")
        {
            print("Trapped!");
            StartCoroutine(Stun(other));
            playerStats.TakeDamage(bearTrapDamage, 1);
        }
    }
}
