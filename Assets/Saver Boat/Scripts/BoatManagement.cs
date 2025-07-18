using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BoatManagement : MonoBehaviour {

    [Header(" Elements ")]

    [SerializeField] private Transform boatManagement;

    [SerializeField] private Transform stickManGroup;

    [SerializeField] private Transform stickManGroupPrefab;


    private bool groupCreated;


    private void Start() {
        
    }

    private void Update() {
        
    }






    private void CreateStickManGroup(Transform stickManGroup,Vector3 positionBoat) {

        if (groupCreated) {

            return;

        }



        Transform stickManParent = stickManGroup.GetChild(0);



        

        Instantiate(stickManGroupPrefab, positionBoat, Quaternion.identity,boatManagement);

        groupCreated = true;


        



    }



    private void BoatPositionSet() {
        groupCreated = false;

        for (int i = 0; i < boatManagement.childCount; i++) {
          
                Transform stickManGroup1 = boatManagement.GetChild(i);

                Transform stickManParent = stickManGroup1.GetChild(0);




                if (stickManParent.childCount == 5 && stickManParent.CompareTag("StickManParent")) {


                    int newBoatIndex = boatManagement.childCount;


                    float xOffset = 1.16f;
                    float newX = (newBoatIndex % 2 == 1) ? xOffset : -xOffset;


                    float zOffset = -5.23f;
                    float newZ = zOffset * (newBoatIndex / 2);


                    Vector3 newPosition = new Vector3(newX, 0, newZ);

                    CreateStickManGroup(stickManGroup1, newPosition);

                    stickManParent.tag = "StickManParent_Full";

                    break;
                    

                }
                
            

        }
    }










}