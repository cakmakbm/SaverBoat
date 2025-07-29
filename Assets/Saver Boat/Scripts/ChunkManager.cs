using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditorInternal;
using UnityEngine;

public class ChunkManager : MonoBehaviour {
  public static ChunkManager instance;

  [Header(" Elements ")] 
  [SerializeField] private LevelSO[] levels;

  private GameObject finishLine;

  private void Awake() {
    if (instance!=null) {
      Destroy(gameObject);
           
    }
    else {
      instance = this;

    }
    
  }

  private void Start() {
    GenerateLevel();
    finishLine = GameObject.FindWithTag("Finish");
  }
  
  private void Update() {
    
    
    
    
    
  }

  private void GenerateLevel() {

    int currentLevel = GetLevel();
    currentLevel = currentLevel % levels.Length;

    LevelSO level = levels[currentLevel];
    
    CreateLevel(level.chunks);


  }

  private void CreateLevel(Chunk[] levelChunks) {

    Vector3 chunkPosition = Vector3.zero;

    for (int i = 0; i <levelChunks.Length ; i++) {

      Chunk chunkToCreate = levelChunks[i];
      chunkPosition.y = -4.6f;

      if (i>0) {
        chunkPosition.z += chunkToCreate.GetLength() / 2;
        

      }

      Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

      chunkPosition.z += chunkInstance.GetLength() / 2;

    }
  }

  

 






  

  public float GetFinishZ() {

    return finishLine.transform.position.z;

    
  }

  public int GetLevel() {

    return PlayerPrefs.GetInt("level", 0);

  }

  public int GetCount() {
    int currentLevel = GetLevel();
    currentLevel = currentLevel % levels.Length;
   LevelSO level= levels[currentLevel];
   return level.GetNeedStickmanNumber();
  }

  

}
