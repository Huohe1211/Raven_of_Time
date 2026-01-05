using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStage 
{
   
        public Vector3 Position;
        public Sprite Sprite;
        public bool IsRight;
        public Vector2 Velocity;

        // 必须有这个构造函数，且参数顺序要和 Record() 里 new 的时候一致
        public ObjectStage(Vector3 pos, Sprite sp, bool right, Vector2 vel)
        {
            Position = pos;
            Sprite = sp;
            IsRight = right;
            Velocity = vel;
        }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
