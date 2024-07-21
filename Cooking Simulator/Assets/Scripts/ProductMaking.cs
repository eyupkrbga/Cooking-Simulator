using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductMaking : MonoBehaviour
{
    public GameObject[] playerObjects;
    public GameObject[] stands;
    public GameObject[] standObjects;
    public GameObject yetersizBakiye;

    public Text kahveSayisiGosterici;
    public Text patatesSayisiGosterici;
    public Text sandvicSayisiGosterici;

    public int[] makingTime;

    public bool[] isPlayerMakingArea;
    public bool[] isPlayerDeliveryArea;
    public bool[] isProductMaking;
    public bool[] isProductReady;

    public int playersProductInt = 5;

    public int karakterdekiUrunSayisi;
    
    public bool isPlayerBin;
    public bool playersObject;

    public bool Parasizlik;

    float turnSpeed = 50f;

    public MusteriHareketi musteriHareketi;
    public paraSistemi _parasistemi;
    
    public void Start()
    {
        musteriHareketi = FindObjectOfType<MusteriHareketi>();
    }
    
    public void Update()
    {
        if(Parasizlik)
            StartCoroutine(YetersizBakiye());
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayerMakingArea[i] && !isProductReady[i] && !isProductMaking[i])
            {
                if((_parasistemi.para - _parasistemi.maliyet[i/3]) >= 0)
                {
                    _parasistemi.para = _parasistemi.para - _parasistemi.maliyet[i/3]; 
                    StartCoroutine(delay(i));
                }
                else
                    StartCoroutine(YetersizBakiye());
            }
            if (Input.GetKeyDown(KeyCode.E) && isPlayerMakingArea[i] && isProductReady[i] && !playersObject)
            {
                standObjects[i].SetActive(false);
                playerObjects[i/3].SetActive(true);
                karakterdekiUrunSayisi = 1;
                playersProductInt = (i/3) + 1;
                isProductReady[i] = false;
                playersObject = true;
            }
            if (Input.GetKeyDown(KeyCode.E) && isPlayerMakingArea[i] && isProductReady[i] && playersProductInt == (i/3) + 1)
            {
                standObjects[i].SetActive(false);
                isProductReady[i] = false;
                karakterdekiUrunSayisi++;
            }

            if (Input.GetKeyDown(KeyCode.E) && playersObject && isPlayerBin)
            {
                karakterdekiUrunSayisi--;
                if(karakterdekiUrunSayisi == 0)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        playerObjects[k].SetActive(false);
                    }
                    playersProductInt = 0;
                    playersObject = false;
                }
            }
        }
        if(playersProductInt == 0)
        {
            kahveSayisiGosterici.text = " ";
            patatesSayisiGosterici.text = " ";
            sandvicSayisiGosterici.text = " ";
        }
        if(playersProductInt == 1)
        {
            kahveSayisiGosterici.text = karakterdekiUrunSayisi + " ";
        }
        if(playersProductInt == 2)
        {
            patatesSayisiGosterici.text = karakterdekiUrunSayisi + " ";
        }
        if(playersProductInt == 3)
        {
            sandvicSayisiGosterici.text = karakterdekiUrunSayisi + " ";
        }
    
        for (int j = 0; j < 3; j++)
        {
            if (playersObject)
            {
                playerObjects[j].transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
            }
        }
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < 9; i++)
        {
            if(collision.gameObject.CompareTag("Stand" + (i+1)))
            {
                isPlayerMakingArea[i] = true;
            }
        }
        for (int k = 0; k < 3; k++)
        {
            if(collision.gameObject.CompareTag("Musteri" + (k+1)))
            {
                isPlayerDeliveryArea[k] = true;
            }
        }
        if (collision.gameObject.tag == "Bin")
        {
            isPlayerBin = true;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        for (int i = 0; i < 9; i++)
        {
            if(collision.gameObject.CompareTag("Stand" + (i+1)))
            {
                isPlayerMakingArea[i] = false;
            }
        }
        for (int k = 0; k < 3; k++)
        {
            if(collision.gameObject.CompareTag("Musteri" + (k+1)))
            {
                isPlayerDeliveryArea[k] = false;
            }
        }
        if (collision.gameObject.tag == "Bin")
        {
            isPlayerBin = false;
        }
    }

    IEnumerator delay(int index)
    {
        isProductMaking[index] = true;
        yield return new WaitForSeconds(makingTime[index/3]);
        isProductReady[index] = true;
        standObjects[index].SetActive(true);
        isProductMaking[index] = false;
    }

    IEnumerator YetersizBakiye()
    {
        yetersizBakiye.SetActive(true);
        yield return new WaitForSeconds(2f);
        Parasizlik = false;
        yetersizBakiye.SetActive(false);
    }

}