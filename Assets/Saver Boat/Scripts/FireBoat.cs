using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoat : MonoBehaviour {

    [Header(" Settings ")] 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletStartTransform;
    [SerializeField] private float fireRate = 0.2f;
    
    
     private float nextFireTime;
     private bool canFire;


     private void Start() {
         GameManager.onGameStateChanged += GameStateChangedCallBack;
     }
    

     

     private void Update() {
         if (canFire) {
            Fire();             
         }
      
        
        
     }

     private void OnDestroy() {
         
         GameManager.onGameStateChanged -= GameStateChangedCallBack;
         
     }

     private void GameStateChangedCallBack(GameManager.GameState gameState) {

         if (gameState== GameManager.GameState.Game) {
             StartFire();
             
         }
         else if (gameState== GameManager.GameState.LevelComplete) {
             StopFire();
         }
            
         else if (gameState== GameManager.GameState.Menu) {
             StopFire();
         }
         
         
     }

    private Vector3 GetStickmanGroupBulletPosition(Vector3 startPos) {

       
        
        
      
        return new Vector3(startPos.x, startPos.y + 0.3f, startPos.z + 4f);
    }
    


    private void FireBullet(Transform childTransform) {

        GameObject bullet = ObjectPooler.Instance.GetPooledGameObject();

        if (bullet!= null) {

            bullet.transform.position= GetStickmanGroupBulletPosition(childTransform.position);
            bullet.transform.rotation = bulletStartTransform.rotation;
            
            bullet.SetActive(true);
            

        }
            

    }

    private void StartFire() {

        canFire = true;

    }
    private void StopFire() {

        canFire = false;

    }

    private void Fire() {
        
        
        if (Time.time >= nextFireTime)
        {
            
            nextFireTime = Time.time + fireRate;
            if (bulletStartTransform.childCount==1) {
                FireBullet(bulletStartTransform.GetChild(0));
            }

            if (bulletStartTransform.childCount==2) {
                FireBullet(bulletStartTransform.GetChild(0));
                FireBullet(bulletStartTransform.GetChild(1));
                
            }  
            if (bulletStartTransform.childCount>=3) {
                FireBullet(bulletStartTransform.GetChild(0));
                FireBullet(bulletStartTransform.GetChild(1));
                FireBullet(bulletStartTransform.GetChild(2));
                
            }

          
            
        }
        
    }
}
