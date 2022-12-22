using UnityEngine;

public class PlayerParameterBase: CharacterParameterBase
{
   
    [SerializeField]
    private int playerHitPoint;

    [SerializeField]
    private int playerAttackPoint;

    private void Start()
    {
        // ダンジョンの記録があるのでそこからhitpointを取得する
        if (DungeonMemoryManager.Instance.GetPlayerHitPoint != 0)
        { 
            base.HitPoint = DungeonMemoryManager.Instance.GetPlayerHitPoint;
            base.maxHitPoint = DungeonMemoryManager.Instance.GetPlayerMaxHitPoint;
        }
        else {
            base.HitPoint = playerHitPoint;
            base.maxHitPoint = base.HitPoint;
        }
        base.AttackPoint = playerAttackPoint;
    }

}
