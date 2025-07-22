using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour {
    [Header(" Elements ")] 
    [SerializeField] private SpriteRenderer rightDooRenderer;
    [SerializeField] private SpriteRenderer leftDooRenderer;
    [SerializeField] private TextMeshPro righTextMeshPro;
    [SerializeField] private TextMeshPro leftDoorTextMeshPro;
    [SerializeField] private Collider collider;

    [Header(" Settings ")] 
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;
    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    private void Update() {
        
    }
}
