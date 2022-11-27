using UnityEngine;

public class EnemyParameterBase : MonoBehaviour
{
    // 外部的要因でパラメーターを変化させたい場合があるのでpublicで作成
    public CharacterParameterBase EnemyCharacterParameter;

    [SerializeField]
    private int hitPoint;

    [SerializeField]
    private int attackPoint;

    private void Awake()
    {
        EnemyCharacterParameter = new CharacterParameterBase(hitPoint, attackPoint);
    }
}
