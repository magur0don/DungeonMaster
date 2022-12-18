using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultSceneScoreViewer : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = DungeonScoreManager.Instance.GetDungeonScore.ToString();
    }

}
