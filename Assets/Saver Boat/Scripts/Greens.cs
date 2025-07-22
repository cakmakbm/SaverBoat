using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BonusType {
    Addition, 
    Difference,
    Product,
    Division,
    Speed
};
public class Greens : MonoBehaviour {
    [SerializeField] private int bonusAmount;
    [SerializeField] private BonusType greenBonusType;
   

    public int GetBonusAmount() {
        return bonusAmount;
    }

    public BonusType GetBonusType() {
        return greenBonusType;
    }
}
