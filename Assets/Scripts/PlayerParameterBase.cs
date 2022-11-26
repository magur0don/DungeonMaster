using UnityEngine;

public class PlayerParameterBase: MonoBehaviour
{
    // 外部的要因でパラメーターを変化させたい場合があるのでpublicで作成
    public CharacterParameterBase PlayerCharacterParameter;

    [SerializeField]
    private int hitPoint;

    [SerializeField]
    private int attackPoint;

    private void Awake()
    {
        PlayerCharacterParameter = new CharacterParameterBase(hitPoint, attackPoint);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            PlayerCharacterParameter.HitPoint -= 10;
            Debug.Log(PlayerCharacterParameter.HitPoint);
        }
    }
}
