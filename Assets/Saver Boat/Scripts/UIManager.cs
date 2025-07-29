using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    
    
   [Header(" Elements ")]
   [SerializeField] private GameObject menuPanel;
   [SerializeField] private GameObject gamePanel;
   [SerializeField] private GameObject gameOverPanel;
   [SerializeField] private GameObject levelComplete;
   [SerializeField] private GameObject settingsPanel;
   [SerializeField] private Slider progressBar;
   [SerializeField] private TextMeshProUGUI levelText;
   [SerializeField] private TextMeshProUGUI playText;
   [SerializeField] private TextMeshProUGUI stickmanText;
   [SerializeField] private TextMeshProUGUI menuLevelText;
   [SerializeField] private TextMeshProUGUI lastLevelText;
   [SerializeField] private TextMeshProUGUI nextLevelText;
   [SerializeField] private ChunkManager chunkManager;
   [SerializeField] private CrowdSystem crowdSystem;
   private int needStickman;
   private int stickmanNumber;
   private bool winCon;


   private void Awake() {
      
      


   }

   private void Start() {
      menuLevelText.text = "Level " + (ChunkManager.instance.GetLevel()+1);
      lastLevelText.text = "Level " + (ChunkManager.instance.GetLevel());
      nextLevelText.text = "Level " + (ChunkManager.instance.GetLevel()+2);
      needStickman = chunkManager.GetCount();
      
      
      progressBar.value = 0;
      gamePanel.SetActive(false);
      gameOverPanel.SetActive(false);
      settingsPanel.SetActive(false);
      levelText.text = "Level " + (ChunkManager.instance.GetLevel()+1);
      
      

      GameManager.onGameStateChanged += GameStateChangedCallback;

   }

   private void OnDestroy() {
      
      GameManager.onGameStateChanged -= GameStateChangedCallback;
   }

   private void GameStateChangedCallback(GameManager.GameState gameState) {

      if (gameState==GameManager.GameState.GameOver) {
         
         ShowGameOver();
         
      }

      if (gameState==GameManager.GameState.LevelComplete) {
         
         ShowLevelComplete();

      }
      
   }

   private void Update() {
       
      UptadeProggressBar();
      UptadeStickanText();

   }

   public void PlayButtonPressed() {
      
   GameManager.instance.SetGameState(GameManager.GameState.Game);   
   
   menuPanel.SetActive(false);
   gamePanel.SetActive(true);
   

   }

   public void RetryButtonPressed() {
      
      SceneManager.LoadScene(0);

   }

   public void ShowGameOver() {
      
      gamePanel.SetActive(false);
      gameOverPanel.SetActive(true);
      
   }

   public void ShowLevelComplete() {
      
      gameOverPanel.SetActive(false);
      levelComplete.SetActive(true);
      
   }

   public void UptadeProggressBar() {
      if (GameManager.instance.IsGameState()) {
         
         float proggress =  BoatController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();

         progressBar.value = proggress;

         
      }


   }

   public void UptadeStickanText() {
      if (GameManager.instance.IsGameState()) {
         stickmanNumber = crowdSystem.GetTotalStickmanCount();

         



         if (stickmanNumber>needStickman) {
            stickmanNumber = needStickman;
            stickmanText.color = Color.green;

         }
         

         if (progressBar.value>0.5f && stickmanNumber<needStickman ) {
            
          //  stickmanText.color= Color.red;
            
         }
         stickmanText.text = stickmanNumber +"/"+needStickman;


      }
   }

   public void ShowSettingsPanel() {
      
      settingsPanel.SetActive(true);
      
   }

   public void HideSettingsPanel() {
      
      settingsPanel.SetActive(false);
      
      
   }

   
   
   
}
