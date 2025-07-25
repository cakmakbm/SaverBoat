using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour {
    [Header(" Settings ")] 
    private bool haptics;
    
    private void Start() {
        PlayerDetection.onDoorsHit += Vibrate;
        PlayerDetection.onRunnerDied += Vibrate;
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameManager.GameState gameState) {
        if (gameState == GameManager.GameState.LevelComplete) {
            Vibrate();

        }

        else if (gameState == GameManager.GameState.GameOver) {

            Vibrate();

        }
    }

    private void OnDestroy() {
        PlayerDetection.onDoorsHit -= Vibrate;
        PlayerDetection.onRunnerDied -= Vibrate;
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }



    private void Vibrate() {

        if (haptics) {
            Taptic.Light();
        }

    }

    public void DisableVibration() {

        haptics = false;

    }

    public void EnableVibration() {

        haptics = true;

    }

}
