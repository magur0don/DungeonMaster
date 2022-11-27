using UnityEngine;

public class PlayerParameterBase: CharacterParameterBase
{
   
    [SerializeField]
    private int hitPoint;

    [SerializeField]
    private int attackPoint;

    protected PlayerParameterBase(int hitPoint, int attackPoint) : base(hitPoint, attackPoint)
    {
        this.hitPoint = hitPoint;
        this.attackPoint = attackPoint;
    }
}
