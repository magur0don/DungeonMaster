using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    Button startButton;
    private void Start()
    {
        GameTurnManager.playerActionCount = 0;
        DungeonSoundManager.Instance.PlayeBGM( DungeonSoundManager.BGMType.DungeonTitleBGM);
        DungeonScoreManager.Instance.DungeonScoreInit();
        DungeonMemoryManager.Instance.DungeonMemoryManagerInit();
        startButton.onClick.AddListener(()=> {
            SceneTransitionManager.Instance.SceneLoad("SampleScene");
        });
    }

}
