using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour { 
   private CrowdSystem crowdSystem;

   private void Awake() {
      crowdSystem = FindAnyObjectByType<CrowdSystem>();
   }

   private void Update() {
      DetectGreens();
   }


   private void DetectGreens() {
      Collider[] detectColliders =
         Physics.OverlapBox(transform.position, new Vector3(1f, 0.53f, 2.51f), Quaternion.identity);
      for (int i = 0; i < detectColliders.Length; i++) {

         if (detectColliders[i].TryGetComponent(out Greens greens)) {
            int bonusAmount = greens.GetBonusAmount();
            BonusType bonusType = greens.GetBonusType();
               crowdSystem.AppylyBonus(bonusType, bonusAmount);
               Debug.Log("Detected");
               Destroy(greens.gameObject);


         }

         if (detectColliders[i].TryGetComponent(out Enemy enemy)) {
            int bonusAmount = enemy.GetBonusAmount();
            BonusType bonusType = enemy.GetBonusType();
            crowdSystem.AppylyBonus(bonusType, bonusAmount);
            Destroy(enemy.gameObject);
            Debug.Log("Enemy karsilastild");
         }
         
      }
   }
   
   
}
