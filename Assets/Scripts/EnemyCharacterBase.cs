using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterBase : CharacterBase
{
    // Start is called before the first frame update
    void Start()
    {

        this.transform.position = MapGenerator.EnemyPos[0];
    }

    // Update is called once per frame
    public override void Update()
    {
        Debug.Log(GameTurnManager.playerAction);
        if (GameTurnManager.playerAction) {
            var rand = Random.Range(0,5);
            Debug.Log("1aaa");
            switch (rand) {
                case 0:

                    base.SetArrowState(Arrow.Left);
                    break;

                case 1:
                    base.SetArrowState(Arrow.Up);

                    break;

                case 2:
                    base.SetArrowState(Arrow.Down);
                    break;

                case 3:

                    base.SetArrowState(Arrow.Right);
                    break;

                case 4:
                    base.IsAttack = true;
                    break;

            }
        }
        base.Update();
    }
}
