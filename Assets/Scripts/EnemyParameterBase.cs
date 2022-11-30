using UnityEngine;

public class EnemyParameterBase : CharacterParameterBase
{
    [SerializeField]
    private float enemyHitPoint;

    [SerializeField]
    private float enemyAttackPoint;

    private void Awake()
    {
        base.HitPoint = enemyAttackPoint;
        base.maxHitPoint = base.HitPoint;
        base.AttackPoint = enemyAttackPoint;
    }
}
