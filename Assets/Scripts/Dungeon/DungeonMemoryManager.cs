using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ダンジョンを跨いだ際の記憶を行います
public class DungeonMemoryManager : SingletonMonoBehaviour<DungeonMemoryManager>
{
    private float playerHitPoint = 0f;
    public float GetPlayerHitPoint {

        get { return playerHitPoint; }
    }

    private float playerMaxHitPoint = 0f;
    public float GetPlayerMaxHitPoint
    {

        get { return playerMaxHitPoint; }
    }

    private float playerAttackPoint = 0f;
    public float GetPlayerAttackPoint
    {
        get { return playerAttackPoint; }
    }

    public void DungeonMemoryManagerInit() {
        playerHitPoint = 0f;
        playerMaxHitPoint = 0f;
        playerAttackPoint = 0f;
    }

    public void SetPlayerParameter(CharacterParameterBase playerParameter)
    {
        playerHitPoint = playerParameter.GetHitPoint;
        playerMaxHitPoint = playerParameter.GetMaxHitPoint;
        playerAttackPoint = playerParameter.GetAttackPoint;
    }
}
