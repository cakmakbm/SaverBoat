using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDoor : MonoBehaviour {
   [Header(" Elements ")] 
   [SerializeField] private float pillarDistance = 3f;
   


   public virtual float GetPillarDistance() {

      return pillarDistance;
   }
}
