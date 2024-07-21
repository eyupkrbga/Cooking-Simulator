using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject upgradeMenu;
    public GameObject Muzik;
    public GameObject[] muzikTuslari;
    public bool muzikAcikMi = true;
    public bool durduMu = false;
    public bool upgradeAcik = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(upgradeAcik)
            {
                upgradeAcik = false;
                Resume();
            }
            else if (durduMu)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        durduMu = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        upgradeMenu.SetActive(false);
        durduMu = false;
        Time.timeScale = 1f;
    }

    public void UpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        upgradeAcik = true;
        Time.timeScale = 0;
    }

    public void Music()
    {
        if(muzikAcikMi)
        {
            muzikAcikMi = false;
            Muzik.SetActive(false);
            muzikTuslari[0].SetActive(false);
            muzikTuslari[1].SetActive(true);
        }
        else if(!muzikAcikMi)
        {
            muzikAcikMi = true;
            Muzik.SetActive(true);
            muzikTuslari[0].SetActive(true);
            muzikTuslari[1].SetActive(false);
        }
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
