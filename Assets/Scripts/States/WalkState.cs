using UnityEngine;

public class WalkState : IState
{
    private GameObject character = null;

    private Animator characterAnimator = null;

    private const string Walk = "Walk";

    public enum Arrow {
        Invalide =-1,
        Left,
        Up,
        Right,
        Down
    }
    public Arrow Arrows;

    public void OnEnter(GameObject characterGameObject)
    {
        if (character != null) {
            return;
        }
        character = characterGameObject;
        characterAnimator = character.GetComponentInChildren<Animator>();
    }

    public void OnUpdate()
    {
        if (character == null) {
            Debug.LogError("Characterが参照されていません");
        }
        var FloorToIntPos = Vector3Int.FloorToInt(character.transform.position);

        character.transform.position = FloorToIntPos;
        switch (Arrows) {
            case Arrow.Invalide:
                break;

            case Arrow.Left:
                // 左に移動
                if (CheckPos(FloorToIntPos += Vector3Int.left)) {

                    character.transform.position += Vector3Int.left;
                    characterAnimator.SetBool(Walk, true);
                }
                
                break;

            case Arrow.Up:
                // 上に移動
                if (CheckPos(FloorToIntPos += Vector3Int.up))
                {

                    character.transform.position += Vector3Int.up;
                    characterAnimator.SetBool(Walk, true);
                }
                break;

            case Arrow.Right:
                // 右に移動
                if (CheckPos(FloorToIntPos += Vector3Int.right))
                {
                    character.transform.position += Vector3Int.right;
                    characterAnimator.SetBool(Walk, true);
                }
                break;

            case Arrow.Down:
                // 下に移動
                if (CheckPos(FloorToIntPos += Vector3Int.down))
                {
                    character.transform.position += Vector3Int.down;
                    characterAnimator.SetBool(Walk, true);
                }
                break;
        }
    }

    public void OnExit()
    {
        if (Arrows == Arrow.Invalide) {
            return;
        }
        Arrows = Arrow.Invalide;
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
