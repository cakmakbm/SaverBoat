using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotation : MonoBehaviour
{
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;
    private Quaternion originalRotation;
    private Quaternion targetRotation;
  
  
    private void Update() {
        
        moveWithInput();
    }

  

    private void moveWithInput() {

        if (Input.GetMouseButtonDown(0)) {

            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
      
      
      
            if (clickedScreenPosition.x < Screen.width / 2 ) {
        
                transform.Rotate(0,0,-25);
            }
            else if(clickedScreenPosition.x > Screen.width / 2 ){
        
                transform.Rotate(0, 0, 25);
        
            }
      
        }
      

        if (Input.GetMouseButtonUp(0)) {

            transform.rotation = originalRotation;
        }
    
   
    
    
    }
}
