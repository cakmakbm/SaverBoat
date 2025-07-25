using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level", order = 0)]
public class LevelSO : ScriptableObject {
    
    public Chunk[] chunks;
    [SerializeField] private int needStickmanNumber;

    public int GetNeedStickmanNumber() {
        return needStickmanNumber;
    }

}
