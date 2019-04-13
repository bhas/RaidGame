using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

	private List<Color> colors = new List<Color> { Color.red, Color.blue, Color.yellow, Color.green, Color.magenta, Color.cyan, Color.magenta };

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    this.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Count)];
    }
}
