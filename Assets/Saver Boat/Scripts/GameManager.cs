using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
   public static GameManager instance;
   private GameState gameState;

   public static Action<GameState> onGameStateChanged;
   public enum GameState {
      
      Menu,
      Game,
      LevelComplete,
      GameOver
      
   }
   


   private void Awake() {

      if (instance != null) {

         Destroy(gameObject);

      }
      else
         instance = this;

   }

   private void Start() {
      
      
   }

   public void SetGameState(GameState gameState) {
      this.gameState = gameState;
      onGameStateChanged?.Invoke(gameState);
      
      Debug.Log("GameState Changed to " + gameState );
   
   }

   public bool IsGameState() {
      return gameState == GameState.Game;
   }
   
   

}
