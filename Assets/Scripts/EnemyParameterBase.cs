using UnityEngine;

public class EnemyParameterBase : CharacterParameterBase
{
    // 外部的要因でパラメーターを変化させたい場合があるのでpublicで作成
    public CharacterParameterBase EnemyCharacterParameter;

    [SerializeField]
    private int hitPoint;

    [SerializeField]
    private int attackPoint;

    protected EnemyParameterBase(int hitPoint, int attackPoint) : base(hitPoint, attackPoint)
    {
        this.hitPoint = hitPoint;
        this.attackPoint = attackPoint;
    }

}
