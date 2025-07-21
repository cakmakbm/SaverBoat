using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotation : MonoBehaviour {
    [Tooltip("Teknenin sağa veya sola ne kadar eğileceğini belirleyen açı.")]
    [SerializeField] private float tiltAngle = 15.0f;

    [Tooltip("Eğilme ve düzelme animasyonunun ne kadar hızlı olacağı.")]
    [SerializeField] private float rotationSpeed = 5.0f;

    private Quaternion originalRotation; // Teknenin orijinal, düz duruş rotasyonu
    private Quaternion targetRotation;   // Ulaşmak istediğimiz anlık rotasyon

    void Start()
    {
        // Oyun başladığında teknenin ilk, düz duruş rotasyonunu kaydediyoruz.
        // Bu sayede her zaman bu orijinal duruşa geri dönebiliriz.
        originalRotation = transform.rotation;
        targetRotation = originalRotation;
    }

    private void Update() 
    {
        // 1. GİRDİYİ KONTROL ET VE HEDEF ROTASYONU BELİRLE

        // Eğer fareye basılı tutuluyorsa...
        if (Input.GetMouseButton(0)) { // Down yerine GetMouseButton kullanıyoruz

            // Eğer ekranın sol yarısına basılıyorsa...
            if (Input.mousePosition.x < Screen.width / 2 ) {
                // Hedefimiz, orijinal duruşun sola doğru tiltAngle kadar eğilmiş halidir.
                targetRotation = originalRotation * Quaternion.Euler(0, 0, tiltAngle);
            }
            // Eğer ekranın sağ yarısına basılıyorsa...
            else {
                // Hedefimiz, orijinal duruşun sağa doğru tiltAngle kadar eğilmiş halidir.
                targetRotation = originalRotation * Quaternion.Euler(0, 0, -tiltAngle);
            }
        }
        // Eğer fare bırakılmışsa...
        else {
            // Hedefimiz tekrar orijinal, düz duruş pozisyonudur.
            targetRotation = originalRotation;
        }
      
        // 2. MEVCUT ROTASYONDAN HEDEF ROTASYONA YUMUŞAK GEÇİŞ YAP
        
        // Her karede, mevcut rotasyonumuzu hedef rotasyona doğru rotationSpeed hızında yumuşakça yaklaştırıyoruz.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
