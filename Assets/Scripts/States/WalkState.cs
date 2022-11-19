using UnityEngine;

public class WalkState : IState
{
    private GameObject character = null;




    public WalkState(GameObject characterGameObject) {

        if (character != null)
        {
            return;
        }
        character = characterGameObject;
    }

    public void OnEnter()
    {
        // 何かWalkをするときにチェックしたいことがあれば追加
    }

    public void OnUpdate()
    {
      
    }


}
