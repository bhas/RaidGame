
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;

	public CharacterController Controller;
	public SpriteRenderer HealthBar;
	public SpriteRenderer ShieldBar;
	public float Speed = 2;
	public float Health;
	public float Shield;

	// Start is called before the first frame update
	void Start()
	{
		Controller = this.GetComponent<CharacterController>();
		Controller.enabled = true;
		UpdateHealthBar();
		UpdateShieldBar();
	}

	// Update is called once per frame
	void Update()
	{
		var dx = 0;
		var dz = 0;
		if (Input.GetKey(left))
		{
			dx = -1;
		}

		if (Input.GetKey(right))
		{
			dx = 1;
		}

		if (Input.GetKey(up))
		{
			dz = 1;
		}

		if (Input.GetKey(down))
		{
			dz = -1;
		}
		Controller.SimpleMove(new Vector3(dx, 0, dz) * Speed);
	}

	public void TakeDamage(float damage)
	{
		var healthDamage = 0f;

		if (Shield > 0f)
		{
			float shieldLost;
			if (Shield > damage)
			{
				shieldLost = damage;
				Shield -= damage;
				UpdateShieldBar();
			}
			else
			{
				shieldLost = Shield;
				healthDamage = damage - shieldLost;
			}
			UpdateShieldBar();
		}
		else
		{
			healthDamage = damage;
		}

		Health -= healthDamage;
		UpdateHealthBar();

		if (Health <= 0f)
		{
			print("Seppuku!!!");
			this.gameObject.SetActive(false);
		}
	}

	public void UpdateHealthBar()
	{
		HealthBar.transform.localScale = new Vector3(Health / 10.53f, 1.92f, 1.23f);
		if (Health == 100)
		{
			HealthBar.gameObject.SetActive(false);
		}
		else if (!HealthBar.gameObject.activeSelf)
		{
			HealthBar.gameObject.SetActive(true);
		}

	}

	public void UpdateShieldBar()
	{
		ShieldBar.transform.localScale = new Vector3(Shield / 10.53f, 1.92f, 1.23f);
		if (Shield == 100 || Shield == 0)
		{
			ShieldBar.gameObject.SetActive(false);
		}
		else if (!HealthBar.gameObject.activeSelf)
		{
			ShieldBar.gameObject.SetActive(true);
		}
	}
}
