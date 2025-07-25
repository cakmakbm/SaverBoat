using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header(" Effects ")] 
    [SerializeField] private GameObject deathEffectPrefab;
    [Header(" Settings ")]
    [SerializeField] private BonusType bonusType;
    [SerializeField] private int bonusAmount;
    [SerializeField] private float searchRadius;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private EnemyAnimationHandler[] animationHandler;
    
    
    private State state;
    private Transform targetGroup;
    

    enum State {
        Idle,
        Running,
        Death
        
        
    }

    private void Awake() {
       
       // animationHandler = GetComponentInChildren<EnemyAnimationHandler>();
        
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
            case State.Death:
                moveSpeed = 0;
                rotationSpeed = 0;
                break;
            
        }
    }


    public void InitiateDeath(Vector3 effectPosition) {
        state = State.Death;
        Collider[] colliders = GetComponentsInChildren<Collider>();
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, effectPosition, Quaternion.identity);
        }
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }
        EnemyAnimationHandler[] handlers = GetComponentsInChildren<EnemyAnimationHandler>();

        // 3. Dizideki her bir handler için döngü kur ve animasyonu başlat.
        foreach (EnemyAnimationHandler handler in handlers)
        {
            handler.StartDeathAnimation();
        }

        // 4. Boş tekneyi belirli bir süre sonra yok etmek için Coroutine başlat.
        // Buradaki 3.0f, animasyonun bitmesi için gereken süredir. Kendi animasyonunuza göre ayarlayın.
        StartCoroutine(DestroySelfAfterDelay(2.0f));

       

       /* if (animationHandler!=null) {
            
            animationHandler.StartDeathAnimation();
            
        }

        else {
            
            
            Destroy(gameObject);
            
        }*/
        
    }
    private IEnumerator DestroySelfAfterDelay(float delay)
    {
        // Belirtilen süre kadar bekle.
        yield return new WaitForSeconds(delay);
        
        // Bekleme bittikten sonra tekne objesini yok et.
        Destroy(gameObject);
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
        Quaternion targetRotation = Quaternion.LookRotation(-directionToTarget);

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
