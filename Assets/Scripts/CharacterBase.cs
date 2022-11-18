using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    WalkState WalkState = null;

    private void Awake()
    {
        WalkState = new WalkState(this.gameObject);
    }

    private void Start()
    {
      
    }

    public virtual void Update()
    {
        WalkState.OnUpdate();

    }
    private void LateUpdate()
    {
        WalkState.OnExit();
    }

    protected void SetState(WalkState.Arrow arrow) {

        WalkState.Arrows = arrow;
    }

}
