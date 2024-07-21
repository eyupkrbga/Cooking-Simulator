using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRandomizer : MonoBehaviour
{
    public GameObject[] Sapkalar;
    public GameObject[] Govdeler;
    public GameObject[] Sortlar;
    public GameObject[] Ayakkabilar;

    public int sapka, govde, sort, ayakkabi;

    public bool karakterOlustur;
    public bool karakterSil;

    public void Update()
    {
        if(karakterOlustur)
        {
            KarakterRandomizer();
            Sapkalar[sapka].SetActive(true);
            Govdeler[govde].SetActive(true);
            Sortlar[sort].SetActive(true);
            Ayakkabilar[ayakkabi].SetActive(true);
            karakterOlustur = false;
        }
        if(karakterSil)
        {
            KarakterSilici();
        }

    }
    public void KarakterSilici()
    {
        sapka = 0;
        govde = 0;
        sort = 0;
        ayakkabi = 0;
        for(int i = 0; i < 5; i++)
        {
            Sapkalar[i].SetActive(false);
            Govdeler[i].SetActive(false);
            Sortlar[i].SetActive(false);
            Ayakkabilar[i].SetActive(false);
        }
        karakterSil = false;
    }

    public void KarakterRandomizer()
    {
        sapka = Random.Range(0, 5);
        govde = Random.Range(0, 5);
        sort = Random.Range(0, 5);
        ayakkabi = Random.Range(0, 5);
    }

}
