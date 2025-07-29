using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayPulse : MonoBehaviour
{// Animasyon ayarlarını Inspector'dan kolayca değiştirmek için
    [Header("Animasyon Ayarları")]
    [SerializeField] private float buyumeMiktari = 1.2f; // Ne kadar büyüyecek? (1.2 = %120)
    [SerializeField] private float animasyonSuresi = 0.5f; // Büyüme ve küçülmenin toplam süresi
    [SerializeField] private Vector3 originalSizeVector3;

    void Start()
    {
        // Animasyonu başlat
        PlayPulseEffect();
    }

    public void PlayPulseEffect()
    {
        // Önceki animasyonları durdur (isteğe bağlı ama güvenli)
        transform.DOKill();

        // Bir Sequence oluştur. Bu, animasyonları zincirlememizi sağlar.
        Sequence pulseSequence = DOTween.Sequence();

        // 1. Adım: Büyüme Animasyonu
        // Objeyi 'buyumeMiktari' kadar büyüt. Sürenin yarısını bu adıma ayır.
        pulseSequence.Append(transform.DOScale(buyumeMiktari, animasyonSuresi / 2));

        // 2. Adım: Normal Haline Dönme Animasyonu
        // Objeyi orijinal boyutuna (1,1,1) geri getir. Sürenin diğer yarısını bu adıma ayır.
        pulseSequence.Append(transform.DOScale(originalSizeVector3, animasyonSuresi / 2));

        
        pulseSequence.SetLoops(-1, LoopType.Restart);
    }
}
