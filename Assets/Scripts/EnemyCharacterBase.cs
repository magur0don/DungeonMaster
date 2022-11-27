using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyCharacterBase : CharacterBase
{

    private bool isChase = false;

    private int chaseDirection = 0;
    float playerDiff = 10f;
    // Start is called before the first frame update
    void Start()
    {

        this.transform.position = MapGenerator.EnemyPos[0];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            isChase = true;
            Vector3 v = (collision.transform.position - this.transform.position).normalized;
            playerDiff = (collision.transform.position - this.transform.position).magnitude;
            var face = Vector3Int.zero;
            // 自分より左側にプレイヤーがいる
            if (v.x < 0)
            {
                chaseDirection = (int)Arrow.Left;
                face = Vector3Int.left;
            }
            // 自分より右側にプレイヤーがいる
            if (v.x > 0)
            {
                chaseDirection = (int)Arrow.Right;
                face = Vector3Int.right;
            }
            // 自分より下側にプレイヤーがいる
            if (v.y < 0)
            {
                chaseDirection = (int)Arrow.Down;
                face = Vector3Int.down;
            }
            // 自分より上側にプレイヤーがいる
            if (v.y > 0)
            {
                chaseDirection = (int)Arrow.Up;
                face = Vector3Int.up;
            }
            if (playerDiff <= 2)
            {
                base.LookToDirection(face);
            }
        }
    }

    // 索敵範囲からでた場合は追跡モードを外す
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            isChase = false;
        }
    }

    public override void Update()
    {
        if (GameTurnManager.playerAction) {

            if (isChase)
            {
                // プレイヤーと自分との距離が近ければ攻撃する
                if (playerDiff <= 2)
                {
                    base.IsAttack = true;
                    
                }
                else {// そうでなければプレイヤーをおう
                    base.SetArrowState((Arrow)chaseDirection);
                }
            }
            else
            {
                var rand = Random.Range(0, 4);
                switch (rand)
                {
                    case 0:
                        base.SetArrowState(Arrow.Left);
                        break;

                    case 1:
                        base.SetArrowState(Arrow.Up);
                        break;

                    case 2:
                        base.SetArrowState(Arrow.Right);
                        break;

                    case 3:
                        base.SetArrowState(Arrow.Down);
                        break;
                }
            }
        }
        base.Update();
    }
}
