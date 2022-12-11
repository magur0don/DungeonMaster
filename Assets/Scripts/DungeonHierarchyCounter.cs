using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHierarchyCounter : SingletonMonoBehaviour<DungeonHierarchyCounter>
{
    [SerializeField]
    private int dungeonHierarchyCount;

    public int GetDungeonHierarchyCount
    {
        get
        {
            return dungeonHierarchyCount;
        }
    }

    public void DungeonHierarchyCountUP()
    {
        dungeonHierarchyCount++;
    }
}
