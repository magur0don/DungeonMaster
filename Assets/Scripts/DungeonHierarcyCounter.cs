using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHierarcyCounter : SingletonMonoBehaviour<DungeonHierarcyCounter>
{
    
    private int dungeonHierarchyCount = 1;

    public int GetDungeonHierarchyCount {

        get { return dungeonHierarchyCount; }
    }

    public void DundeonHierarchyCountUp() {
        dungeonHierarchyCount++;
    }
}
