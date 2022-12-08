using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public enum EnemyType {
        Invalide =-1,
        Normal,
        High
    }

    public GameObject[] Enemy = new GameObject[2];

    public void EnemySpawn(Vector2 spawnPos, EnemyType enemyType) {
        var enemy = Instantiate(Enemy[(int)enemyType]);
        enemy.transform.position = spawnPos;
    }
}
