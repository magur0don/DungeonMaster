using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetirePoint : MonoBehaviour
{
    [SerializeField]
    private GameObject TextModalPrefab;

    private int playerLayar = 0;

    private void Awake()
    {
        // TextModal用のPrefabを生成
        TextModalPrefab = Instantiate(TextModalPrefab);
        TextModalPrefab.SetActive(false);
        int layerNo = LayerMask.NameToLayer("Player");
        // マスクへの変換（ビットシフト）
        playerLayar = 1 << layerNo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayar)
        {
            TextModalPrefab.SetActive(true);
            var characters = FindObjectsOfType<CharacterBase>();
            foreach (var character in characters) {
                // キャラクターの移動を不活性にする
                character.isActive = false;
            }
        }
    }
}
