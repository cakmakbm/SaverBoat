using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {
    [SerializeField] private Vector3 size;











    public float GetLength() {
        return size.z;
    }

    public float GetWidth() {
        return size.x;
    }
    private void OnDrawGizmos() {
        Gizmos.color= Color.blue;
        Gizmos.DrawWireCube(transform.position,size);
    }
}
