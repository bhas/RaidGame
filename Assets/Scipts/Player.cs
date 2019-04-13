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
	public float Speed = 2;
	public int Health = 5;

    // Start is called before the first frame update
    void Start()
    {
	    Controller = this.GetComponent<CharacterController>();
	    Controller.enabled = true;
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

	public void TakeDamage(int damage)
	{
		Health -= damage;

		if (Health <= 0)
		{
			print("Seppuku!!!");
			this.gameObject.SetActive(false);
		}
	}
}
