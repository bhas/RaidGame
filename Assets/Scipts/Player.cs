using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public CharacterController Controller;
	public SpriteRenderer HealthBar;
	public SpriteRenderer ShieldBar;
	public float Speed;
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
	    var dx = Input.GetAxis("Horizontal");
	    var dy = Input.GetAxis("Vertical");
		Controller.SimpleMove(new Vector3(dx, 0, dy) * Speed);
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
	}

	public void UpdateShieldBar()
	{
		ShieldBar.transform.localScale = new Vector3(Shield / 10.53f, 1.92f, 1.23f);
	}
}
