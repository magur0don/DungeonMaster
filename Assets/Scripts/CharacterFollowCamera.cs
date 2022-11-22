using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollowCamera : MonoBehaviour
{
    public PlayerCharacterBase PlayerCharacterBase;
    // Update is called once per frame
    void LateUpdate()
    {
        var pos = PlayerCharacterBase.gameObject.transform.position;
        pos.z = -1;
        this.transform.position = pos;
    }
}
