using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button resultButton;

    // Start is called before the first frame update
    void Start()
    {
        DungeonSoundManager.Instance.PlayeBGM(DungeonSoundManager.BGMType.DungeonResultBGM);

        resultButton.onClick.AddListener(() => {
            SceneTransitionManager.Instance.SceneLoad("TitleScene");

        });

    }

}
