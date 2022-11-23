using UnityEngine;

public class PlayerParameterBase: MonoBehaviour
{
    // 外部的要因でパラメーターを変化させたい場合があるのでpublicで作成
    public CharacterParameterBase characterParameter;

    [SerializeField]
    private int hitPoint;

    [SerializeField]
    private int attackPoint;

    private void Awake()
    {
        characterParameter = new CharacterParameterBase(hitPoint, attackPoint);
    }
}
