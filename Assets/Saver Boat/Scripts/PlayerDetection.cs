using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour {
   [Header(" Events ")] 
   public static Action onDoorsHit;

   public static Action onRunnerDied;
   
   private CrowdSystem crowdSystem;
   private BoatController boatController;
   private bool isSpeedBoostActive;
   private float speedBoostEndTime;
   private float originalSpeed;
   private Collider selfCollider;
   private UIManager uiManager;
   

   private void Awake() {
      uiManager = GetComponent<UIManager>();
      selfCollider = GetComponent<Collider>();
      crowdSystem = FindAnyObjectByType<CrowdSystem>();
      boatController = FindAnyObjectByType<BoatController>();
   }

   private void Update() {
      if (GameManager.instance.IsGameState()) {
         
         DetectGreens();
      }
   
      // Hız artışı aktif mi diye kontrol et
      if (isSpeedBoostActive)
      {
         // Şu anki zaman, bitiş zamanını geçti mi?
         if (Time.time >= speedBoostEndTime)
         {
            // Zaman doldu, her şeyi eski haline getir.
            boatController.SetMovementSpeed(originalSpeed);
            isSpeedBoostActive = false; // Bayrağı indir ki bu if bloğu bir daha çalışmasın.
            Debug.Log("Hız artışı bitti!");
         }
      }
   }


   private void DetectGreens() {
      Collider[] detectColliders =
         Physics.OverlapBox(transform.position, new Vector3(1f, 0.53f, 2.51f), Quaternion.identity);
      for (int i = 0; i < detectColliders.Length; i++) {

         if (detectColliders[i].TryGetComponent(out Greens greens)) {
            int bonusAmount = greens.GetBonusAmount();
            BonusType bonusType = greens.GetBonusType();
               crowdSystem.ApplyBonus(bonusType, bonusAmount);
               Debug.Log("Detected");
               onDoorsHit?.Invoke();
               Destroy(greens.gameObject);


         }

         if (detectColliders[i].TryGetComponent(out Enemy enemy)) {
            
            int bonusAmount = enemy.GetBonusAmount();
            BonusType bonusType = enemy.GetBonusType();
            crowdSystem.ApplyBonus(bonusType, bonusAmount);
           // CharAnimationHandler handler = enemy.GetComponent<CharAnimationHandler>();
           Collider enemyCollider = enemy.GetComponent<Collider>();
           Vector3 effectPosition;
           if (selfCollider != null && enemyCollider != null)
           {
              // Kendi collider'ımızın, düşmanın pozisyonuna en yakın noktasını buluyoruz.
              // Bu, oldukça doğru bir temas noktası tahmini verir.
              effectPosition = selfCollider.ClosestPoint(enemy.transform.position);
           }
           else
           {
              // Eğer bir sebepten collider'lar bulunamazsa, düşmanın merkezini kullan.
              effectPosition = enemy.transform.position;
           }
           onRunnerDied?.Invoke();
           enemy.InitiateDeath(effectPosition);
           
           // Destroy(enemy.gameObject);
           // Debug.Log("Enemy karsilastild");
         }

         if (detectColliders[i].TryGetComponent(out SpeedDoor speedDoor)) {
            float boostDuration = 5f; // Süreyi bir değişkene almak daha temizdir

            // EĞER BU İLK HIZ ARTIŞIYSA...
            if (!isSpeedBoostActive)
            {
               // ...sadece ilk seferde orijinal hızı kaydediyoruz ki süre bitince dönebilelim.
               originalSpeed = boatController.GetMovementSpeed();
               isSpeedBoostActive = true;
            }

            // --- BU KISIM HEM İLK SEFERDE HEM DE STACK'LERKEN HER ZAMAN ÇALIŞIR ---
    
            // 1. Yeni hızı ayarla (belki farklı kapılar farklı hızlar veriyordur)
            float newSpeed = boatController.GetMovementSpeed()+speedDoor.GetNewSpeed();
            boatController.SetMovementSpeed(newSpeed);

            // 2. Bitiş zamanını, ŞU ANKİ zamandan 10 saniye sonrasına AYARLA veya SIFIRLA.
            // Bu, sürenin her seferinde yeniden başlamasını sağlar.
            speedBoostEndTime = Time.time + boostDuration;
    
            Debug.Log("Hız artışı (yenilendi)! Yeni bitiş zamanı: " + speedBoostEndTime);
            onDoorsHit?.Invoke();

            Destroy(speedDoor.gameObject);


            }

         if (detectColliders[i].TryGetComponent(out Door door)) {
            int bonusAmount = door.GetBonusAmount(transform.position.x);
            BonusType bonusType = door.GetBonusType(transform.position.x);
            door.Disable();
            crowdSystem.ApplyBonus(bonusType, bonusAmount);
            onDoorsHit?.Invoke();
            Destroy(door.gameObject);
            
         }

         if (detectColliders[i].CompareTag("Finish")) {
            
            
            
           
            


               PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
               GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);
               // SceneManager.LoadScene(0);
            

         }
         
         
         
         
         
         }
      }
   }
   
   

