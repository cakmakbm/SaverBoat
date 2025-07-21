using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header(" Settings ")]
    [SerializeField] private BonusType bonusType;
    [SerializeField] private int bonusAmount;
    [SerializeField] private float searchRadius;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    private State state;
    private Transform targetGroup;
    

    enum State {
        Idle,
        Running
        
        
    }

    private void Update() {
        ManageState();
    }

    private void ManageState() {
        switch (state) {
            case State.Idle:
                SearchForTarget();
                break;
            case State.Running:
                RunTowardsTarget();
                break;
            
        }
    }

  
    private void RunTowardsTarget()
    {
        if (targetGroup == null)
        {
            state = State.Idle;
            return;
        }

        // --- DÖNME MANTIĞI ---

        // 1. Adım: Hedefe olan yön vektörünü bul.
        Vector3 directionToTarget = targetGroup.position - transform.position;
    
        // Y ekseninde dönmesini istemiyorsak (havaya kalkmaması için)
        directionToTarget.y = 0; 

        // 2. Adım: O yöne bakması gereken ideal rotasyonu hesapla.
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // 3. Adım: Mevcut rotasyondan hedef rotasyona doğru yumuşakça (Slerp) geçiş yap.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        // --- HAREKET MANTIĞI ---
    
        // Düz gitmek yerine artık baktığı yöne doğru ilerlemesi daha doğal olabilir.
        // Ama MoveTowards da hala iş görür.
        transform.position = Vector3.MoveTowards(transform.position, targetGroup.position, moveSpeed * Time.deltaTime);
    
        // Alternatif hareket:
        // transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void SearchForTarget() {
        Collider[] detectColliders = Physics.OverlapSphere(transform.position, searchRadius);
        for (int i = 0; i < detectColliders.Length; i++) {
            if (detectColliders[i].TryGetComponent(out StickmanGroup stickmanGroup)) {

              
                stickmanGroup.SetTarget();
                targetGroup = stickmanGroup.transform;
                StartRunningTowardsTarget();
            }
        }
    }

    private void StartRunningTowardsTarget() {
        state = State.Running;
        
        
    }

    public int GetBonusAmount() {


        return bonusAmount;

    }

    public BonusType GetBonusType() {
        return bonusType;
    }
}
