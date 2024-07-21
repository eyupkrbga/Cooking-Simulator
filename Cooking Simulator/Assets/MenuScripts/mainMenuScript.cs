using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public GameObject[] muzikTuslari;
    public GameObject girisMuzigi;
    public bool muzikAcikMi = true;
    
    public void playGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }  

    public void Muzik()
    {
        if(muzikAcikMi)
        {
            muzikAcikMi = false;
            girisMuzigi.SetActive(false);
            muzikTuslari[0].SetActive(false);
            muzikTuslari[1].SetActive(true);
        }
        else if(!muzikAcikMi)
        {
            muzikAcikMi = true;
            girisMuzigi.SetActive(true);
            muzikTuslari[0].SetActive(true);
            muzikTuslari[1].SetActive(false);
        }
    }


    public void quitMenu()
    {
        Application.Quit();
    }
}
