using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradesMenu : MonoBehaviour
{
    public GameObject[] Musteriler;
    public GameObject[] MusteriYildizlar;
    public Text MusteriUcreti;

    public GameObject[] KahveMakineleri;
    public GameObject[] KahveMasalari;
    public GameObject[] KahveStandlari;
    public GameObject[] KahveYildizlar;
    public Text KahveArttirmaUcreti;
    
    public GameObject[] Fritozler;
    public GameObject[] PatatesMasalari;
    public GameObject[] PatatesStandlari;
    public GameObject[] PatatesYildizlar;
    public Text PatatesArttirmaUcreti;

    public GameObject[] SandvicKesmeTahtasi;
    public GameObject[] SandvicMasalari;
    public GameObject[] SandvicStandlari;
    public GameObject[] SandvicYildizlar;
    public Text SandvicArttirmaUcreti;

    public GameObject OyunuBitir;

    public ProductMaking productMaking;
    public MusteriHareketi musteriHareketi;
    public paraSistemi _parasistemi;

    public int MusteriUpgradeUcreti = 50, KahveUpgradeUcreti = 75, PatatesUpgradeUcreti = 100, SandvicUpgradeUcreti = 125;
    public int MusteriUpgradelendi, KahveUpgradelendi, PatatesUpgradelendi, SandvicUpgradelendi;

    public void Start()
    {
        MusteriUcreti.text = MusteriUpgradeUcreti + "TL";
        KahveArttirmaUcreti.text = KahveUpgradeUcreti + "TL";
        PatatesArttirmaUcreti.text = PatatesUpgradeUcreti + "TL";
        SandvicArttirmaUcreti.text = SandvicUpgradeUcreti + "TL";
    }

    public void Update()
    {
        if(MusteriUpgradelendi == 2 && KahveUpgradelendi == 2 && PatatesUpgradelendi == 3 && SandvicUpgradelendi == 3)
        {
            OyunuBitir.SetActive(true);
        }
    }

    public void MusteriSayisiUpgrade()
    {
        if (_parasistemi.para - MusteriUpgradeUcreti >= 0 && MusteriUpgradelendi != 2)
        {
            if(MusteriUpgradelendi < 2)
            {
                MusteriUpgradelendi++;
            }
            Musteriler[MusteriUpgradelendi-1].SetActive(true);
            MusteriYildizlar[MusteriUpgradelendi-1].SetActive(true);

            _parasistemi.para = _parasistemi.para - MusteriUpgradeUcreti;
            MusteriUpgradeUcreti = MusteriUpgradeUcreti + 25;
            MusteriUcreti.text = MusteriUpgradeUcreti + "TL";
            if(MusteriUpgradelendi == 2)
                MusteriUcreti.text = "MAX";
        }
        else if (MusteriUpgradelendi == 2)
        {
            Debug.Log("Daha fazla guclendirme yapilamaz");
        }
        else
        {
            productMaking.Parasizlik = true;
        }
    }
    public void KahveMakinesiUpgrade()
    {
        if (_parasistemi.para - KahveUpgradeUcreti >= 0 && KahveUpgradelendi != 2)
        {
            if(KahveUpgradelendi < 2)
            {
                KahveUpgradelendi++;
            }
            KahveMakineleri[KahveUpgradelendi-1].SetActive(true);
            KahveMasalari[KahveUpgradelendi-1].SetActive(true);
            KahveStandlari[KahveUpgradelendi-1].SetActive(true);
            KahveYildizlar[KahveUpgradelendi-1].SetActive(true);
            
            _parasistemi.para = _parasistemi.para - KahveUpgradeUcreti;
            KahveUpgradeUcreti = KahveUpgradeUcreti + 25;
            KahveArttirmaUcreti.text = KahveUpgradeUcreti + "TL";
            if(KahveUpgradelendi == 2)
                KahveArttirmaUcreti.text = "MAX";
        }
        else if (KahveUpgradelendi == 2)
        {
            Debug.Log("Daha fazla guclendirme yapilamaz");
        }
        else
        {
            productMaking.Parasizlik = true;
        }
    }

    public void PatatesKizartmasiUpgrade()
    {
        if (_parasistemi.para - PatatesUpgradeUcreti >= 0 && PatatesUpgradelendi != 3)
        {
            if(PatatesUpgradelendi < 3)
            {
                PatatesUpgradelendi++;
            }
            Fritozler[PatatesUpgradelendi-1].SetActive(true);
            PatatesMasalari[PatatesUpgradelendi-1].SetActive(true);
            PatatesStandlari[PatatesUpgradelendi-1].SetActive(true);
            PatatesYildizlar[PatatesUpgradelendi-1].SetActive(true);
            
            _parasistemi.para = _parasistemi.para - PatatesUpgradeUcreti;
            PatatesUpgradeUcreti = PatatesUpgradeUcreti + 25;
            PatatesArttirmaUcreti.text = PatatesUpgradeUcreti + "TL";
            if(PatatesUpgradelendi == 3)
                PatatesArttirmaUcreti.text = "MAX";
        }
        else if (PatatesUpgradelendi == 3)
        {
            Debug.Log("Daha fazla guclendirme yapilamaz");
        }
        else
        {
            productMaking.Parasizlik = true;
        }
    }

    public void SandvicTezgahiUpgrade()
    {
        if (_parasistemi.para - SandvicUpgradeUcreti >= 0 && SandvicUpgradelendi != 3)
        {
            if(SandvicUpgradelendi < 3)
            {
                SandvicUpgradelendi++;
            }
            SandvicKesmeTahtasi[SandvicUpgradelendi-1].SetActive(true);
            SandvicMasalari[SandvicUpgradelendi-1].SetActive(true);
            SandvicStandlari[SandvicUpgradelendi-1].SetActive(true);
            SandvicYildizlar[SandvicUpgradelendi-1].SetActive(true);
            
            _parasistemi.para = _parasistemi.para - SandvicUpgradeUcreti;
            SandvicUpgradeUcreti = SandvicUpgradeUcreti + 25;
            SandvicArttirmaUcreti.text = SandvicUpgradeUcreti + "TL";
            if(SandvicUpgradelendi == 3)
                SandvicArttirmaUcreti.text = "MAX";
        }
        else if (SandvicUpgradelendi == 3)
        {
            Debug.Log("Daha fazla guclendirme yapilamaz");
        }
        else
        {
            productMaking.Parasizlik = true;
        }
    }
    
    public void EndTheGame()
    {
        SceneManager.LoadScene(2);
    }
}
