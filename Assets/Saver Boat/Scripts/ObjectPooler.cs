using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler Instance;

    [Header(" Elements ")] 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize;

    private List<GameObject> pooledObjects;

    private void Awake() {

        Instance = this;

    }

    private void Start() {

        pooledObjects = new List<GameObject>();

        for (int i = 0; i< poolSize; i++) {

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pooledObjects.Add(bullet);

        }
    
    }

    public GameObject GetPooledGameObject() {

        for (int i = 0; i< pooledObjects.Count; i++) {

            if (!pooledObjects[i].activeInHierarchy) {

                return pooledObjects[i];

            }
            
            
        }

        return null;

    }
    
}
