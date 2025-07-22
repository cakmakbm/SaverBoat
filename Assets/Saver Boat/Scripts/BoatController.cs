using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatController : MonoBehaviour {
  [Header(" Settings ")] 
  [SerializeField] private float movementSpeed;
  [SerializeField] private float slideSpeed;
  
 
  private Vector3 clickedScreenPosition;
  private Vector3 clickedPlayerPosition;
  private Quaternion originalRotation;
  private Quaternion targetRotation;
  
  
  private void Update() {
    MoveForward();
    moveWithInput();
  }

  private void MoveForward() {

    transform.position += Vector3.forward * movementSpeed * Time.deltaTime;

  }

  private void moveWithInput() {

    if (Input.GetMouseButtonDown(0)) {

      clickedScreenPosition = Input.mousePosition;
      clickedPlayerPosition = transform.position;
      
      
      
     /* if (clickedScreenPosition.x < Screen.width / 2 ) {
        
        transform.Rotate(0,0,-25);
      }
      else if(clickedScreenPosition.x > Screen.width / 2 ){
        
        transform.Rotate(0, 0, 25);
        
      }*/
      
    }
    else if(Input.GetMouseButton(0)){

    if (clickedScreenPosition.x < Screen.width / 2 ) {
      
      clickedPlayerPosition = (Vector3.right + Vector3.forward).normalized;
        
      }
      else if(clickedScreenPosition.x > Screen.width / 2 ){
        
        clickedPlayerPosition = (Vector3.forward + Vector3.left).normalized;
        

      }

      transform.position += clickedPlayerPosition * movementSpeed * Time.deltaTime;

    }

   /* if (Input.GetMouseButtonUp(0)) {

      transform.rotation = originalRotation;
    }*/
   
  }
  public float GetMovementSpeed() {

    return movementSpeed;
  }
  /*public float GetSlideSpeed() {

    return slideSpeed;
  }*/

  public void SetMovementSpeed(float newSpeed) {

    movementSpeed = newSpeed;


  }
  
 /* public void SetSlideSpeed(float newSpeed) {

    slideSpeed = newSpeed;


  }*/
  
}
