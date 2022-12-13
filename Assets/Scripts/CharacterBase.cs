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

    protected bool IsAttack = false;

    private float animationNormalizedTime = 0;

    private Vector3Int characterDirection = Vector3Int.zero;

    private string currentAnimationName = string.Empty;

    protected bool isEnemy = false;

    public CharacterParameterBase characterParameter;

    // 動いて良いというフラグ
    public bool isActive = true;

    private void Awake()
    {
        characterAnimator = this.gameObject.GetComponentInChildren<Animator>();
        characterParameter = this.gameObject.GetComponentInChildren<CharacterParameterBase>();
    }

    public virtual void Update()
    {

        // フラグが折れている場合は操作不能にする
        if (!isActive) {
            return;
        }

        if (characterParameter.isDead()) {
            Debug.Log($"{this.name}:死んだ");
        }


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
        animationNormalizedTime = characterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    protected void SetArrowState(Arrow arrow)
    {
        Arrows = arrow;
    }

    public void LookToDirection(Vector3Int direction) {

        characterAnimator.SetFloat("X", direction.x);
        characterAnimator.SetFloat("Y", direction.y);
        characterDirection = direction;
    }


    private void AnimationExecution(string animationName,Vector3Int direction)
    {
        currentAnimationName = animationName;
        characterAnimator.SetBool(animationName, true);
        characterAnimator.SetFloat("X", direction.x);
        characterAnimator.SetFloat("Y", direction.y);
        characterAnimator.SetTrigger("Clicked");
        if (animationName == Attack)
        {
            StartCoroutine(AttackAnimationExecution());
        }
        else {// ただの移動なら攻撃のモーションを即座にキャンセル
            characterAnimator.SetBool(Attack, false);
            characterAnimator.SetTrigger("Clicked");
        }
    }

    // 攻撃のアニメーションの時にダメージを負わせる実装
    private IEnumerator AttackAnimationExecution() {
        var opponentFace = Vector3.zero;
        opponentFace = characterDirection;
        // アニメーションの途中で
        yield return new WaitUntil(() => animationNormalizedTime > 0.5f);

        if (isEnemy)
        {
            // 敵の場合はプレイヤーに対して当てるRayを放つ
            int layerNo = LayerMask.NameToLayer("Player");
            // マスクへの変換（ビットシフト）
            int layerMask = 1 << layerNo;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, opponentFace, 1.5f, layerMask);
            Debug.Log(layerMask);
            if (hit.collider != null)
            {
                hit.transform.GetComponent<CharacterParameterBase>().Damage(characterParameter.GetAttackPoint);
                Debug.Log($"{hit.transform.name}:{hit.transform.GetComponent<CharacterParameterBase>().GetHitPoint}");
            }
        }
        else {
            int layerNo = LayerMask.NameToLayer("Enemy");
            // マスクへの変換（ビットシフト）
            int layerMask = 1 << layerNo;
            // プレイヤーが敵に攻撃するばあい
            RaycastHit2D hit = Physics2D.Raycast(transform.position, opponentFace, 1.5f, layerMask);
            if (hit.collider != null )
            {
                hit.collider.transform.parent.GetComponent<CharacterParameterBase>().Damage(characterParameter.GetAttackPoint);
                Debug.Log($"{hit.transform.name}:{hit.transform.GetComponent<CharacterParameterBase>().GetHitPoint}");
            }
        }


        yield return new WaitUntil(()=>animationNormalizedTime > 1);
        characterAnimator.SetBool(Attack, false);
        characterAnimator.SetTrigger("Clicked");
    }


    // 進む先に壁がないかをチェックする
    private bool CheckPos(Vector3 vec)
    {
        if (MapGenerator.Instance.map[(int)vec.x, (int)vec.y] == 1)
        {
            return false;
        }
        return true;
    }
}
