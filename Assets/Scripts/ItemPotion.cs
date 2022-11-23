using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotion : MonoBehaviour
{
    public PotionBase Potion;

    [SerializeField]
    private string potionName = string.Empty;

    [SerializeField]
    private int healAmount;

    private void Awake()
    {
        Potion = new PotionBase(potionName, ItemBase.ItemTypes.Portion,healAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            var playerParam = collision.gameObject.GetComponent<PlayerParameterBase>();
            playerParam.PlayerCharacterParameter.Heal(healAmount);
        }
    }

}
