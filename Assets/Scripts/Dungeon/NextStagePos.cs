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
            GameTurnManager.playerActionCount = 0;
            DungeonScoreManager.Instance.AddDungeonScore(5);
            DungeonMemoryManager.Instance.SetPlayerParameter(collision.gameObject.GetComponent<CharacterParameterBase>());
            DungeonHierarchyCounter.Instance.DungeonHierarchyCountUP();
            DungeonSoundManager.Instance.PlaySE( DungeonSoundManager.SEType.NextStagePosSE);
            SceneTransitionManager.Instance.SceneLoad("SampleScene");

        }
    }
}
