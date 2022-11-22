using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private const string Attack = "Attack";

    private string currentAnimationName = string.Empty;

    protected bool IsAttack = false;


    private Vector3Int characterDirection = Vector3Int.zero;

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
                    characterDirection = Vector3Int.left;
                    this.transform.position += characterDirection;
                    AnimationExecution(Walk, characterDirection);
                }
                break;

            case Arrow.Up:
                // 上に移動
                if (CheckPos(FloorToIntPos += Vector3Int.up))
                {
                    characterDirection = Vector3Int.up; 
                    this.transform.position += characterDirection;
                    AnimationExecution(Walk, characterDirection);
                }
                break;

            case Arrow.Right:
                // 右に移動
                if (CheckPos(FloorToIntPos += Vector3Int.right))
                {
                    characterDirection = Vector3Int.right;
                    this.transform.position += characterDirection;
                    AnimationExecution(Walk, characterDirection);

                }
                break;

            case Arrow.Down:
                // 下に移動
                if (CheckPos(FloorToIntPos += Vector3Int.down))
                {
                    characterDirection = Vector3Int.down;
                    this.transform.position += characterDirection;
                    AnimationExecution(Walk, characterDirection);
                }
                break;
        }
        Arrows = Arrow.Invalide;

        if (IsAttack)
        {
            AnimationExecution(Attack, characterDirection);
            IsAttack = false;
        }
    }

    protected void SetArrowState(Arrow arrow)
    {
        Arrows = arrow;
    }


    private void AnimationExecution(string animationName,Vector3Int direction)
    {
        // 違うアニメーションがきた場合、前のステートのアニメーションをオフにする
        if (currentAnimationName != animationName) {
            characterAnimator.SetBool(currentAnimationName, false);
            currentAnimationName = animationName;
        }

        characterAnimator.SetBool(animationName, true);
        characterAnimator.SetFloat("X", direction.x);
        characterAnimator.SetFloat("Y", direction.y);
        characterAnimator.SetTrigger("Clicked");
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