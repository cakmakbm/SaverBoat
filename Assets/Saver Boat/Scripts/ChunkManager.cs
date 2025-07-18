using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {
  [Header(" Elements ")] 
  [SerializeField] private Chunk[] levelChunks;

  private void Start() {
    CreateLevel(levelChunks);
  }

  private void Update() {
    
    
    
  }

  private void CreateLevel(Chunk[] levelChunks) {

    Vector3 chunkPosition = Vector3.zero;


    for (int i = 0; i < levelChunks.Length; i++) {

      Chunk chunkToCreate = levelChunks[i];
      chunkPosition.y = -4.6f;
      if (i > 0)
        chunkPosition.z += chunkToCreate.GetLength() / 2;

      Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
      chunkPosition.z += chunkToCreate.GetLength() / 2;
     
    }






  }
}
