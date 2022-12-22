using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ダンジョンのスタート時点の処理を行う
public class DungeonStartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DungeonSoundManager.Instance.PlayeBGM();
    }

}
