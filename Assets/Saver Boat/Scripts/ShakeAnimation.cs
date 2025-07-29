using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeAnimation : MonoBehaviour
{
    // Inspector'dan ayarlamak için değişkenler
    [SerializeField] private float sure = 1f;
    [SerializeField] private float siddet = 10f;
    [SerializeField] private int vibrato = 10;
    
    void Start()
    {
        // Oyunu başlatır başlatmaz sürekli titretmek için:
        PlayShakeEffect();
    }

    public void PlayShakeEffect()
    {
        // 1 saniye boyunca, 10 birim şiddetinde, 10 vibrato ile titre.
        // UI için sadece X ve Y ekseninde titremesi yeterlidir, bu yüzden Z'ye 0 veriyoruz.
        transform.DOShakePosition(sure, new Vector3(siddet, siddet, 0), vibrato)
            .SetLoops(-1, LoopType.Restart); // Sürekli döngü için
    }
}
