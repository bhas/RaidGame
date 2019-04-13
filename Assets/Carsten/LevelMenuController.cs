using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    private bool[] playerReady = new bool[4];
    private int playersReady;
    private bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerReady.Length; i++)
            playerReady[i] = false;
        playersReady = 0;
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameReady();
    }

    public void ReadyClick(int playerNumber)
    {
        playersReady = playerReady[playerNumber - 1] ? playersReady - 1 : playersReady + 1;
        playerReady[playerNumber - 1] = !playerReady[playerNumber - 1];
        for (int i = 0; i < playerReady.Length; i++)
            print(string.Format("Player {0} ready: {1} | Game start: {2}", i, playerReady[i], gameStart));
    }

    public void GameReady()
    {
        gameStart = playersReady == playerReady.Length;
    }
}
