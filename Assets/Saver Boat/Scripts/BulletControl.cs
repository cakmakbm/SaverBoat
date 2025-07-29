using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    [Header(" Settings ")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private int damage;
    private CrowdSystem crowdSystem;
    private Rigidbody bulletRb;
    private int finalDamage;
    
    

    private void Awake() {
    
        bulletRb = GetComponent<Rigidbody>();
        crowdSystem = FindObjectOfType<CrowdSystem>();

    }

    private void Start() {
        
    }

    private void Update() {
        
    }


    private void OnEnable() {
        
        if (crowdSystem != null)
        {
            finalDamage = damage + (crowdSystem.GetTotalStickmanCount() / 5);
        }
        else
        {
            finalDamage = damage; 
        }

       

        bulletRb.velocity = transform.forward * bulletSpeed;
        
        Invoke("MakePassive", bulletLifeTime);
        

    }

    private void MakePassive() {
        
        gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision) {

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy!= null) {

            enemy.TakeDamage(damage);
            MakePassive(); 
        }

        
       
        
    }

    private void OnDisable() {
        
        CancelInvoke();
        
    }
    
}
