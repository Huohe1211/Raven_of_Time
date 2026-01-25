using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr: MonoBehaviour
{
    public static GameMgr I;    // Instance;

    public Lvl_01 lvl_01;
    public Raven raven;
    public GameEventSystem gameEventSystem;


    private void Awake()
    {
        I = this;
        lvl_01.Init();
        raven.Init();
        gameEventSystem.Init();



    }


    // Start is called before the first frame update
    void Start()
    {
        I = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
