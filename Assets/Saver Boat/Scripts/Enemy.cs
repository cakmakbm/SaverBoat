using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header(" Settings ")]
    [SerializeField] private BonusType bonusType;
    [SerializeField] private int bonusAmount;


    public int GetBonusAmount() {


        return bonusAmount;

    }

    public BonusType GetBonusType() {
        return bonusType;
    }
}
