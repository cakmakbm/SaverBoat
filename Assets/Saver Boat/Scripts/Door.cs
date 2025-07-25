using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : BaseDoor {
    [FormerlySerializedAs("rightDooRenderer")]
    [Header(" Elements ")] 
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rigthTextMeshPro;
    [SerializeField] private TextMeshPro leftDoorTextMeshPro;
    [SerializeField] private Collider collider;

    [Header(" Settings ")] 
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;
    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    private float positionX;


    private void Start() {
        
        ConfigureDoors();
        
    }

    private void Update() {
        if (collider.enabled) {
            positionX = transform.position.x;
        }
            
        
        
    }

    private void ConfigureDoors() {
        switch (rightDoorBonusType) {
            
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rigthTextMeshPro.text = "+" + rightDoorBonusAmount;
                break;
            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rigthTextMeshPro.text = "-" + rightDoorBonusAmount;
                break;
            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rigthTextMeshPro.text = "x" + rightDoorBonusAmount;
                break;
            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rigthTextMeshPro.text = "/" + rightDoorBonusAmount;
                break;
            
            
        }
        
        switch (leftDoorBonusType) {
            
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorTextMeshPro.text = "+" + leftDoorBonusAmount;
                break;
            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorTextMeshPro.text = "-" + leftDoorBonusAmount;
                break;
            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorTextMeshPro.text = "x" + leftDoorBonusAmount;
                break;
            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorTextMeshPro.text = "/" + leftDoorBonusAmount;
                break;
            
            
        }
        
    }

    public int GetBonusAmount(float x) {

        if ( x >positionX) {
            return rightDoorBonusAmount;

        }
        else{
            return leftDoorBonusAmount;
        }
    }

    public BonusType GetBonusType(float x){
        
        
        if ( x >positionX) {
            return rightDoorBonusType;

        }
        else{
            return leftDoorBonusType;
        }
        
    }

    public void Disable() {
        collider.enabled = false;
    }

    
}
