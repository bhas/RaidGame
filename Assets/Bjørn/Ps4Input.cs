using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ps4Input
{
    public int player;
    public Ps4Input(int player)
    {
        this.player = player;
    }

    public Vector2 GetLeftAnalog()
    {
        var dx = Input.GetAxis($"P{player}_Left_Horizontal");
        var dy = Input.GetAxis($"P{player}_Left_Vertical");
        return new Vector2(dx, dy);
    }

    public Vector2 GetRightAnalog()
    {
        var dx = Input.GetAxis($"P{player}_Right_Horizontal");
        var dy = Input.GetAxis($"P{player}_Right_Vertical");
        return new Vector2(dx, dy);
    }

    public bool GetButtonDown(Ps4Button button)
    {
        var keyCode = GetKeyCode(button);
        return Input.GetKeyDown(keyCode);
    }

    public bool GetButtonUp(Ps4Button button)
    {
        var keyCode = GetKeyCode(button);
        return Input.GetKeyUp(keyCode);
    }

    public bool GetButton(Ps4Button button)
    {
        var keyCode = GetKeyCode(button);
        Console.WriteLine("Keycode");
        return Input.GetKey(keyCode);
    }

    private KeyCode GetKeyCode(Ps4Button button)
    {
        switch (button)
        {
            case Ps4Button.Square:
                if (player == 0) return KeyCode.J;
                if (player == 1) return KeyCode.Joystick1Button0;
                if (player == 2) return KeyCode.Joystick2Button0;
                if (player == 3) return KeyCode.Joystick3Button0;
                if (player == 4) return KeyCode.Joystick4Button0;
                break;
            case Ps4Button.Cross:
                if (player == 0) return KeyCode.K;
                if (player == 1) return KeyCode.Joystick1Button1;
                if (player == 2) return KeyCode.Joystick2Button1;
                if (player == 3) return KeyCode.Joystick3Button1;
                if (player == 4) return KeyCode.Joystick4Button1;
                break;
            case Ps4Button.Circle:
                if (player == 0) return KeyCode.L;
                if (player == 1) return KeyCode.Joystick1Button2;
                if (player == 2) return KeyCode.Joystick2Button2;
                if (player == 3) return KeyCode.Joystick3Button2;
                if (player == 4) return KeyCode.Joystick4Button2;
                break;
            case Ps4Button.Triangle:
                if (player == 0) return KeyCode.I;
                if (player == 1) return KeyCode.Joystick1Button3;
                if (player == 2) return KeyCode.Joystick2Button3;
                if (player == 3) return KeyCode.Joystick3Button3;
                if (player == 4) return KeyCode.Joystick4Button3;
                break;
        }

        throw new NotImplementedException();
    }
}

public enum Ps4Button
{
    Cross, Square, Circle, Triangle
}
