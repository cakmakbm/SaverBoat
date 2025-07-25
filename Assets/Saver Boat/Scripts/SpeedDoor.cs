using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDoor : BaseDoor {
   [Header(" Settings ")] 
   [SerializeField] private BonusType bonusType;
   [SerializeField] private float newSpeed;


   public float GetNewSpeed() {
      return newSpeed;
   }

   public BonusType GetBonusType() {

      return bonusType;

   }

 
}
