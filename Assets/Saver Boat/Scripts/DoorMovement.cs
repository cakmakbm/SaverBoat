using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {
    [Header(" Settings ")] 
    [SerializeField] private float maxMoveDistance;
    [SerializeField] private float moveSpeed;
    private Vector3 startPosition;
    [SerializeField] private Transform chunkTransform;
    private float effectiveMoveDistance;
    private BaseDoor doorInfo;


    private void Awake() {
        doorInfo = GetComponent<BaseDoor>();
    }

    private void Start() {
        
        startPosition = transform.position;
        float pillarOffset = doorInfo.GetPillarDistance();

       
        float minX_boundary = -12.5f;
        float maxX_boundary = 12.5f;

      
        float rightPillarPosition = startPosition.x + pillarOffset;
        float leftPillarPosition = startPosition.x - pillarOffset;

        float distanceToRightEdge = maxX_boundary - rightPillarPosition;
        float distanceToLeftEdge = leftPillarPosition - minX_boundary;
    
      
        effectiveMoveDistance = Mathf.Min(Mathf.Min(distanceToRightEdge, distanceToLeftEdge), maxMoveDistance);
    
        
        if (effectiveMoveDistance < 0)
        {
            effectiveMoveDistance = 0;
        }
    }

    private void Update() {

        // Salınımı, START'TA HESAPLADIĞIMIZ GÜVENLİ MESAFE ile yap
        float offset = Mathf.Sin(Time.time * moveSpeed) * effectiveMoveDistance;

        transform.position = startPosition + new Vector3(offset, 0, 0);

    }
}
