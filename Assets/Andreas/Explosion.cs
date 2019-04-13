using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public GameObject prefab;
	public float NumberOfBullets = 100;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown("space"))
	    {
		    Boom();
	    }
    }

	private void Boom()
	{
		float rotation = 360 / NumberOfBullets;
		Vector3 size = this.GetComponent<Collider>().bounds.size/3;
		float x = Random.Range(-size.x, size.x);
		float z = Random.Range(-size.z, size.z);

		Vector3 position = new Vector3(x,0.1f,z); 

		for (int i = 0; i < NumberOfBullets; i++)
		{
			var bullet = Instantiate(prefab, position, Quaternion.identity);
			bullet.transform.Rotate(Vector3.up, rotation * i);
			bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 100);
			bullet.transform.Rotate(Vector3.right, 90);
		}
	}

}
