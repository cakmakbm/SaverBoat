using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Collider collider;

    private void Awake() {
      
        animator = GetComponent<Animator>();
       
    }

    public void StartDeathAnimation() {

        if (animator != null) {
         
            animator.SetTrigger("Die");
         
         
        }
        
      
    }
    public void DestroyOnAnimationEnd()
    {
      
        Destroy(gameObject);
    }
}
