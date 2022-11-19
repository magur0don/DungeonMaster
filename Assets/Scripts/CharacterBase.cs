using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static WalkState;
using UnityEngine.TextCore.Text;

public class CharacterBase : MonoBehaviour
{
    public enum Arrow
    {
        Invalide = -1,
        Left,
        Up,
        Right,
        Down
    }
    public Arrow Arrows;

    private Animator characterAnimator = null;

    private const string Walk = "Walk";

    private void Awake()
    {
        characterAnimator = this.gameObject.GetComponentInChildren<Animator>();
    }

    public virtual void Update()
    {
        var FloorToIntPos = Vector3Int.FloorToInt(this.transform.position);
        if (this.transform.position != FloorToIntPos)
        {
            this.transform.position = FloorToIntPos;
        }

        switch (Arrows)
        {
            case Arrow.Invalide:
                break;

            case Arrow.Left:
                // 左に移動
                if (CheckPos(FloorToIntPos += Vector3Int.left))
                {
                    this.transform.position += Vector3Int.left;
                    characterAnimator.SetBool(Walk, true);
                }
                break;

            case Arrow.Up:
                // 上に移動
                if (CheckPos(FloorToIntPos += Vector3Int.up))
                {
                    this.transform.position += Vector3Int.up;
                    characterAnimator.SetBool(Walk, true);
                }
                break;

            case Arrow.Right:
                // 右に移動
                if (CheckPos(FloorToIntPos += Vector3Int.right))
                {
                    this.transform.position += Vector3Int.right;
                    characterAnimator.SetBool(Walk, true);
                }
                break;

            case Arrow.Down:
                // 下に移動
                if (CheckPos(FloorToIntPos += Vector3Int.down))
                {
                    this.transform.position += Vector3Int.down;
                    characterAnimator.SetBool(Walk, true);
                }
                break;
        }
        Arrows = Arrow.Invalide;
    }

    protected void SetArrowState(Arrow arrow) {

        Arrows = arrow;
    }

    // 進む先に壁がないかをチェックする
    private bool CheckPos(Vector3 vec)
    {
        if (MapGenerator.map[(int)vec.x, (int)vec.y] == 1)
        {
            return false;
        }
        return true;
    }
}
