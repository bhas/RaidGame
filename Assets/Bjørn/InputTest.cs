using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public InputSource inputSource;
    private Ps4Input input;

    // Start is called before the first frame update
    void Start()
    {
        input = new Ps4Input(inputSource);   
    }

    // Update is called once per frame
    void Update()
    {
        var speed = .5f;
        var movement = speed * input.GetLeftAnalog();
        transform.Translate(movement.x, 0, movement.y, Space.World);

        var dir = input.GetRightAnalog();
        transform.LookAt(transform.position + new Vector3(dir.x, 0, dir.y));

        if (input.GetButtonDown(Ps4Button.Cross))
            print($"Player {inputSource} pressed {Ps4Button.Cross}");
        if (input.GetButtonDown(Ps4Button.Square))
            print($"Player {inputSource} pressed {Ps4Button.Square}");
        if (input.GetButtonDown(Ps4Button.Circle))
            print($"Player {inputSource} pressed {Ps4Button.Circle}");
        if (input.GetButtonDown(Ps4Button.Triangle))
            print($"Player {inputSource} pressed {Ps4Button.Triangle}");
    }
}
