using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetirePoint : MonoBehaviour
{
    [SerializeField]
    private GameObject TextModalPrefab;


    private void Awake()
    {
        // TextModal用のPrefabを生成
        TextModalPrefab = Instantiate(TextModalPrefab);
        TextModalPrefab.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            TextModalPrefab.SetActive(true);
        }
    }
}
