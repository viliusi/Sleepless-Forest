using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Sprites;

public class PlayerMovement : MonoBehaviour
{
	public Material[] material;
	Renderer rend;
	public float Speed;
	public float DodgeMultiplier;

	private Rigidbody2D _rb;
	private Vector3 _lastMovement;

	private bool _coolDown;

	private bool _movementPossible;

	public float StunDuration;

	public PlayerStats playerStats;
	void Start()
	{
		_coolDown = false;
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = material[0];
		_movementPossible = true;
	}

	void Update()
	{
		if (_movementPossible == true)
		{
			//Basic movement, WASD
			if (Input.GetKey(KeyCode.W))
			{
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
				_lastMovement = Vector3.right * Time.deltaTime * Speed;
				transform.Translate(_lastMovement);
			}

			if (Input.GetKey(KeyCode.A))
			{
				_lastMovement = Vector3.left * Time.deltaTime * Speed;
				transform.Translate(_lastMovement);
			}

			//Dodge function, space 
			if (Input.GetKey(KeyCode.Space) && _coolDown == false)
			{
				transform.Translate(_lastMovement * DodgeMultiplier);
				StartCoroutine(DodgeInvincibility());
				StartCoroutine(Cooldown());
			}
		}
	}
	private IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(0.1f);
		_coolDown = true;
		rend.sharedMaterial = material[1];
		yield return new WaitForSeconds(2);
		rend.sharedMaterial = material[0];
		_coolDown = false;
	}

	private IEnumerator DodgeInvincibility()
	{
		rend.sharedMaterial = material[2];
		yield return new WaitForSeconds(0.5f);
		rend.sharedMaterial = material[1];
	}

	private IEnumerator Stun()
	{
		_movementPossible = false;
		yield return new WaitForSeconds(StunDuration);
		_movementPossible = true;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "TrapTag")
		{
			StartCoroutine(Stun());
			playerStats.TakeDamage(BearTrapDamage);
		}
	}
}