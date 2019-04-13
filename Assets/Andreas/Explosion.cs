using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public GameObject prefab;
	public static float NumberOfBullets = 100;
	private float rotation;
	private Vector3 size;
	private Vector3 position;
	private GameObject init;
	// Start is called before the first frame update
	void Start()
    {
	    rotation = 360 / NumberOfBullets;
		size = this.GetComponent<Collider>().bounds.size / 3;
	}

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown("space"))
	    {
		    Destroy(init);
			float x = Random.Range(-size.x, size.x);
		    float z = Random.Range(-size.z, size.z);
			position = new Vector3(x, 0.1f, z);
			init = Instantiate(prefab, position, Quaternion.identity);
			init.transform.Rotate(Vector3.right, 90);
			Invoke("Show3", 0);
		    Invoke("Show2", 1);
		    Invoke("Show1", 2);
		    Invoke("Boom", 3 );
		}
	}

	private void Boom()
	{
		Destroy(init);
		for (int i = 0; i < NumberOfBullets; i++)
		{
			var bullet = Instantiate(prefab, position, Quaternion.identity);
			bullet.transform.Rotate(Vector3.up, rotation * i);
			bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 100);
			bullet.transform.Rotate(Vector3.right, 90);
		}
	}

	private void Show3()
	{
		
		init.GetComponent<SpriteRenderer>().color = Color.green;
	}

	private void Show2()
	{
		init.GetComponent<SpriteRenderer>().color = Color.yellow;
	}

	private void Show1()
	{
		init.GetComponent<SpriteRenderer>().color = Color.red;
	}

}
