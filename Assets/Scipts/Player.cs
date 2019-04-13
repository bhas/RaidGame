using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public CharacterController Controller;
	public float Speed;
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
	    var dx = Input.GetAxis("Horizontal");
	    var dy = Input.GetAxis("Vertical");
		Controller.SimpleMove(new Vector3(dx, 0, dy) * Speed);
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
