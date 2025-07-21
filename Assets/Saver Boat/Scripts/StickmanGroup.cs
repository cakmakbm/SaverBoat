using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanGroup : MonoBehaviour {
    [Header(" Settings ")]
    private bool isTarget;


    private void Update() {
        
    }

    public void SetTarget() {
        isTarget = true;
    }

    public bool IsTarget() {
        return isTarget;
    }
}
