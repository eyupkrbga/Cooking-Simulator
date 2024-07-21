using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusteriHareketi : MonoBehaviour
{
    public List<Transform> Path;

    public float speed = 5f;
    public int currentIndex = 0;
    public bool isCustomerHome, isCustomerArea, canGoHome;
    public int siparisUrunu, siparisSayisi;
    public bool siparisOlusturulduMu, siparisTeslimEdildiMi;

    public GameObject[] Balloons;
    public GameObject[] Numbers;
    
    public bool[] musterininUrunu;

    public int siparisSayisiSiniri;
    public int siparisUrunuSiniri;

    private Animator animator;
    
    public ProductMaking productMaking;
    public CustomerRandomizer customerRandomizer;
    public paraSistemi _parasistemi;
    public UpgradesMenu upgradesMenu;

    void Start()
    {
        siparisSayisiSiniri = 2;
        siparisUrunuSiniri = 2;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!siparisTeslimEdildiMi || isCustomerHome)
        {
            goToArea(Path[currentIndex]);
        }
        else if (siparisTeslimEdildiMi)
        {
            currentIndex = 0;
            goHome(Path[currentIndex]);
        }
        if(isCustomerHome)
        {
            siparisOlusturulduMu = false;
            siparisTeslimEdildiMi = false;
            isCustomerArea = false;
        }
        if(isCustomerArea && !siparisOlusturulduMu)
        {
            siparisOlustur();
        }
        for(int i = 0; i < 3; i++)
        {
            if(Input.GetKeyDown(KeyCode.E) && productMaking.playersProductInt == siparisUrunu && siparisSayisi != 0 && productMaking.isPlayerDeliveryArea[i] && isCustomerArea && musterininUrunu[i] && productMaking.karakterdekiUrunSayisi != 0)
            {
                productMaking.karakterdekiUrunSayisi--;
                _parasistemi.para = _parasistemi.para + _parasistemi.kar[productMaking.playersProductInt - 1]; 
                siparisSayisi--;
                if (siparisSayisi == 0)
                {
                    siparisUrunu = 0;
                    siparisTeslimEdildiMi = true;
                }
            }
        }
        if(productMaking.karakterdekiUrunSayisi == 0)
        {
            for (int e = 0; e < 3; e++)
                {
                    productMaking.playerObjects[e].SetActive(false);
                    productMaking.playersProductInt = 0;
                    productMaking.playersObject = false;
                }
        }

        if(siparisUrunu == 0 && siparisSayisi == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Balloons[i].SetActive(false);
                Numbers[i].SetActive(false);
            }
        }
        for (int i = 0; i < Balloons.Length; i++)
        {
            Balloons[i].SetActive(i == siparisUrunu - 1);
        }

        for (int i = 0; i < Numbers.Length; i++)
        {
            Numbers[i].SetActive(i == siparisSayisi - 1);
        }

        if(upgradesMenu.KahveUpgradelendi >= 1)
        {
            siparisSayisiSiniri = 3;
            if(upgradesMenu.PatatesUpgradelendi >= 2)
            {
                siparisSayisiSiniri = 4;
            }
        }

        if(upgradesMenu.PatatesUpgradelendi >= 1)
        {
            siparisUrunuSiniri = 3;
            if(upgradesMenu.SandvicUpgradelendi >= 1)
                {
                    siparisUrunuSiniri = 4;
                }
        }
        
    }

    public void goToArea(Transform target)
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            animator.SetBool("npcIsWalking", true);
        }
        else
        {
            animator.SetBool("npcIsWalking", false);
        }
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            if (currentIndex == 0)
            {
                customerRandomizer.karakterSil = true;
                currentIndex = 1; 
                isCustomerHome = false;
            }
            else if (currentIndex == 1)
            {
                customerRandomizer.karakterOlustur = true;
                currentIndex = 2; 
            }
            else if (currentIndex == 2)
            {
                currentIndex = 3; 
            }
            else if (currentIndex == 3)
            {
                isCustomerArea = true;
            }
        }
    }
    public void goHome(Transform target)
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            isCustomerHome = true;
        }
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            animator.SetBool("npcIsWalking", true);
        }
        else
        {
            animator.SetBool("npcIsWalking", false);
        }
    }
    public void siparisOlustur()
    {
        siparisUrunu = Random.Range(1, siparisUrunuSiniri);
        siparisSayisi = Random.Range(1, siparisSayisiSiniri);
        siparisOlusturulduMu = true;       
    }

    public void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < 3; i++)
        {
            if(collision.gameObject.CompareTag("MusteriTeslim" + (i+1)))
            {
                musterininUrunu[i] = true;
            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        for (int i = 0; i < 3; i++)
        {
            if(collision.gameObject.CompareTag("MusteriTeslim" + (i+1)))
            {
                musterininUrunu[i] = false;
            }
        }
    }
}
