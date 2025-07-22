using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimationHandler : MonoBehaviour {
   private Animator animator;
   private Collider collider;

   private void Awake() {
      
      animator = GetComponent<Animator>();
      collider = GetComponent<Collider>();
   }

   public void StartDeathAnimation() {

      if (animator != null) {
         
         animator.SetTrigger("Die");
         
         
      }

      if (collider != null) {

         collider.enabled = false;

      }
         
      
   }
   public void DestroyOnAnimationEnd()
   {
      
      Destroy(gameObject);
   }

}
