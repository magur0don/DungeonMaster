using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStagePos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 侵入してきたgameobjectのlayerがPlayerなら
        if (collision.gameObject.layer == 3)
        {
            DungeonScoreManager.Instance.AddDungeonScore(5);
            SceneTransitionManager.Instance.SceneLoad("SampleScene");

        }
    }
}
