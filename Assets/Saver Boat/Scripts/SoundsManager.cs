using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {
   [Header(" Sounds ")] 
   [SerializeField] private AudioSource buttonHitSound;
   [SerializeField] private AudioSource doorHitSound;
   [SerializeField] private AudioSource runnderDieSound;
   [SerializeField] private AudioSource levelCompleteSound;
   [SerializeField] private AudioSource gameOverSound;

   private void Start() {

      PlayerDetection.onDoorsHit += PlayDoorHitSound;
      GameManager.onGameStateChanged += GameStateChangedCallback;
      PlayerDetection.onRunnerDied += PlayRunnerDiedSound;

   }
  
   
  

   private void GameStateChangedCallback(GameManager.GameState gameState) {
      if (gameState==GameManager.GameState.LevelComplete) {
         levelCompleteSound.Play();
         
      }

      else if(gameState == GameManager.GameState.GameOver) {
         
         gameOverSound.Play();
         
      }
   }

   private void OnDestroy() {
      
      PlayerDetection.onDoorsHit -= PlayDoorHitSound;
      
      GameManager.onGameStateChanged -= GameStateChangedCallback;
      
      PlayerDetection.onRunnerDied -= PlayRunnerDiedSound;
   }

   private void PlayRunnerDiedSound() {

      runnderDieSound.Play();

   }

   private void PlayDoorHitSound() {
      
      doorHitSound.Play();
      
   }

   public void DisableSounds() {
      doorHitSound.volume = 0;
      runnderDieSound.volume = 0;
      levelCompleteSound.volume = 0;
      gameOverSound.volume = 0;
      buttonHitSound.volume = 0;

   }

   public void EnableSounds() {
      doorHitSound.volume=1;
      runnderDieSound.volume=1;
      levelCompleteSound.volume=1;
      gameOverSound.volume=1;
      buttonHitSound.volume = 1;


   }
}
