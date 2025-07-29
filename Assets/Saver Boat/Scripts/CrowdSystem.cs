using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour {
   [Header(" Elements ")] 
   [SerializeField] private Transform stickmanParentTransform;
   [SerializeField] private Transform boatParenTransform;
   [SerializeField] private Transform stickmanGroupTransform;
   [SerializeField] private GameObject stickmanPrefab;
   [SerializeField] private GameObject stickmanGroupPrefab;
   
   private void Update() {
      
      if (!GameManager.instance.IsGameState()) {
         
         return;
         
      }
      PlaceOnBoats();

      if (GetTotalStickmanCount()<=0) {
         
         GameManager.instance.SetGameState(GameManager.GameState.GameOver);
         
         
      }
      


   }

  /*private void PlaceOnBoats() {
     Transform stickmanParent = GetStickManGroupTransform().GetChild(0);
     Debug.Log("StickmanParent.childCount = " + stickmanParent.childCount);
      for (int i = 0; i < stickmanParent.childCount; i++) {

         Vector3 childLocalPosition = GetStickManLocalPosition(i);
         stickmanParent.GetChild(i).localPosition = childLocalPosition;
         Debug.Log(i);

      }*/
      private void PlaceOnBoats() {
    
    for (int boatIndex = 0; boatIndex < boatParenTransform.childCount; boatIndex++) {
        
        
        Transform stickmanParent = boatParenTransform.GetChild(boatIndex).GetChild(0);

       
        for (int i = 0; i < stickmanParent.childCount; i++) {
            Vector3 childLocalPosition = GetStickManLocalPosition(i);
            stickmanParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    
   
      
      
   }


   private void PlaceBoats() {
      

      for (int i = 0; i < boatParenTransform.childCount; i++) {
         
         Vector3 childLocalPosition = GetBoatLocalPosition(i);
         boatParenTransform.GetChild(i).localPosition = childLocalPosition;


      }
      
   }
   private Vector3 GetBoatLocalPosition(int index) {
      
      if (index <= 0) {
         return Vector3.zero; 
      }

     
      float x = (index % 2 != 0) ? -1.5f : 1.5f;

     
      int rowIndex = ((index - 1) / 2) + 1;
      float z = rowIndex * -5.0f;

      return new Vector3(x, 0, z);
   }
   

 

   private Transform GetStickManGroupTransform() {
      
      for (int i = 0; i < boatParenTransform.childCount; i++) {
         
         if (boatParenTransform.GetChild(i).GetChild(0).childCount < 5) {
            
            return boatParenTransform.GetChild(i);
         }
      }
      
     
      
      AddStickManGroup();
      PlaceBoats();
      
      return boatParenTransform.GetChild(boatParenTransform.childCount - 1);
   }

   

   private void AddStickManGroup() {
      Instantiate(stickmanGroupPrefab, boatParenTransform);
      
   }


   private void AddRunners(int amount) {
      for (int i = 0; i < amount; i++) {
         Instantiate(stickmanPrefab, GetStickManGroupTransform().GetChild(0));
        
      }
   
      
   }
  

   public void ApplyBonus(BonusType bonusType, int bonusAmount) {
      int total = GetTotalStickmanCount();
      switch (bonusType) {
         case BonusType.Addition:
            AddRunners(bonusAmount);
            break;
         case BonusType.Difference:
            RemoveRunners(bonusAmount);
            break;
         case BonusType.Product:
            
            int stickmanToAdd = total * bonusAmount - total;
            AddRunners(stickmanToAdd);
            break;
         case BonusType.Division:
            int stickManToRemove = total - (total / bonusAmount);
            RemoveRunners(stickManToRemove);
            break;
      }
      
   }
   
   public void RemoveRunners(int amountToRemove)
   {
      int totalStickmen = GetTotalStickmanCount();
      if (amountToRemove > totalStickmen)
      {
         amountToRemove = totalStickmen;
      }

     
      for (int i = 0; i < amountToRemove; i++)
      {
         
         if (boatParenTransform.childCount == 0)
         {
            break;
         }

         Transform lastStickmanGroup = boatParenTransform.GetChild(boatParenTransform.childCount - 1);
         Transform stickmanParent = lastStickmanGroup.GetChild(0);

        

        
         Transform stickmanToDestroy = stickmanParent.GetChild(stickmanParent.childCount - 1);
         CharAnimationHandler charAnimationHandler = stickmanToDestroy.GetComponent<CharAnimationHandler>();
         if (charAnimationHandler != null) {


            stickmanToDestroy.SetParent(null);

            charAnimationHandler.StartDeathAnimation();
            
         }
         else {
            Destroy(stickmanToDestroy.gameObject);
         }

         if (stickmanParent.childCount == 0)
         {
            lastStickmanGroup.SetParent(null);
            Destroy(lastStickmanGroup.gameObject);
            
            
           
            
            
       
         }
      }
   }
   

   private void DestroyLastStickmanGroup() {

      Transform destroyGroup = GetStickManGroupTransform();
      destroyGroup.SetParent(null);
      Destroy(destroyGroup.gameObject);

   }

   public int GetTotalStickmanCount() {
      int total = 0;
      for (int i = 0; i < boatParenTransform.childCount; i++) {
         for (int j = 0; j <boatParenTransform.GetChild(i).GetChild(0).childCount ; j++) {
            total++;

         }
         
      }

      return total;
   }

   private Vector3 GetStickManLocalPosition(int index) {
      float x;
      float z; 
      switch (index) {
         case 0:
            x = 0f;
            z = 0f;
            break;
         case 1:
            x =  (-0.43f);
            z = 1 * (-0.7f);
            break;
         
         case 2:
            x =  (0.43f);
            z = 1 * (-0.7f);
         break;
         
         case 3:
            x =  (-0.43f);
            z = 2 * (-0.7f);
            break;
         
         case 4:
            x = (0.43f);
            z = 2 * (-0.7f);
            break;
         default:
            x = (0.43f);
            z = 2 * (-0.7f);
            break;
      }
      
     

      return new Vector3(x, 0, z);

   }

     
      
   

   private Vector3 GetStickmanCurrenLocation(int index) {
      return stickmanParentTransform.position;
   }

   
}


