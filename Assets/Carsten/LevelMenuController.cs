using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    //bool 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadyClick(int i)
    {
        //print("Player" + i + "ready");
        var str = string.Format("Player {0} ready", i);
        print(str);
    }
}
