using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header(" Settings ")]
    [SerializeField] private BonusType bonusType;
    [SerializeField] private int bonusAmount;
    private State state;

    enum State {
        Idle,
        Running
        
        
    }
    public int GetBonusAmount() {


        return bonusAmount;

    }

    public BonusType GetBonusType() {
        return bonusType;
    }
}
