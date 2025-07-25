using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatController : MonoBehaviour {
  public static BoatController instance;
  
  [Header(" Settings ")] 
  [SerializeField] private float movementSpeed;
  [SerializeField] private float slideSpeed;
  [SerializeField] private float roadWith;
  private bool canMove;
  
  
  
  private Vector3 clickedScreenPosition;
  private Vector3 clickedPlayerPosition;
  private Quaternion originalRotation;
  private Quaternion targetRotation;


  private void Awake() {
    if (instance!= null) {
      Destroy(gameObject);
      
    }
    else {
      instance = this;
    }
  }

  private void Start() {
    
    GameManager.onGameStateChanged += GameStateChangedCallBack;
  }

  private void OnDestroy() {
    GameManager.onGameStateChanged -= GameStateChangedCallBack;
  }


  private void Update() {
    if (canMove) {

      MoveForward();
      moveWithInput();
      
    }
  }
  
  private void GameStateChangedCallBack(GameManager.GameState gameState) {

    if (gameState== GameManager.GameState.Game) {
      StartMoving();
      
    }
    else if (gameState== GameManager.GameState.GameOver) {
      
      StopMoving();
      
    }
    else if ( gameState==GameManager.GameState.LevelComplete) {
      
      StopMoving();
      
    }
    
  }

  private void StartMoving() {

    canMove = true;
  }

  private void StopMoving() {

    canMove = false;
  }

  private void MoveForward() {

    transform.position += Vector3.forward * movementSpeed * Time.deltaTime;

  }

  private void moveWithInput() {

    if (Input.GetMouseButtonDown(0)) {

      clickedScreenPosition = Input.mousePosition;
      clickedPlayerPosition = transform.position;
      
      
      
    }
    else if(Input.GetMouseButton(0)) {
      float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
      xScreenDifference /= Screen.width;
      xScreenDifference *= slideSpeed;
      Vector3 position = transform.position;
      position.x = clickedPlayerPosition.x + xScreenDifference;
      position.x = Mathf.Clamp(position.x, -roadWith / 2 + 1.1f, roadWith / 2 - 1.1f);

      transform.position = position;





    }

  
   
  }
  public float GetMovementSpeed() {

    return movementSpeed;
  }
  

  public void SetMovementSpeed(float newSpeed) {

    movementSpeed = newSpeed;


  }
  
 
  
}
