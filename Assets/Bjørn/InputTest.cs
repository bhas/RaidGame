using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public int player;
    private Ps4Input input;

    // Start is called before the first frame update
    void Start()
    {
        input = new Ps4Input(player);   
    }

    // Update is called once per frame
    void Update()
    {
        var speed = .5f;
        var movement = speed * input.GetLeftAnalog();
        transform.Translate(movement.x, 0, movement.y);

        if (input.GetButtonDown(Ps4Button.Cross))
            print($"Player {player} pressed {Ps4Button.Cross}");
        if (input.GetButtonDown(Ps4Button.Square))
            print($"Player {player} pressed {Ps4Button.Square}");
        if (input.GetButtonDown(Ps4Button.Circle))
            print($"Player {player} pressed {Ps4Button.Circle}");
        if (input.GetButtonDown(Ps4Button.Triangle))
            print($"Player {player} pressed {Ps4Button.Triangle}");
    }
}
