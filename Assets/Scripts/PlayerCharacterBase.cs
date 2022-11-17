using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterBase : CharacterBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            base.SetState(WalkState.Arrow.Left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            base.SetState(WalkState.Arrow.Up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            base.SetState(WalkState.Arrow.Down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            base.SetState(WalkState.Arrow.Right);
        }
        base.Update();
    }
}
