using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public KarakterKontrol karakter;
    public GameObject tirmanmaButonu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (karakter.TirmanabilirMi())
        {
            tirmanmaButonu.SetActive(true);
        }
        else
        {
            tirmanmaButonu.SetActive(false);
            karakter.TirmanmaKarar(0);
        }
    }
}
