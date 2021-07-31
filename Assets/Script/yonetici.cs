using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{
    int saniye = 50;
    int para = 0;
    int hedefpara = 500;
    public GameObject kaybettin_panel;
    public GameObject durdur_panel;
    public GameObject sonrakilevel_panel;
    public TMPro.TextMeshProUGUI saniye_txt;
    public TMPro.TextMeshProUGUI para_txt;
    public TMPro.TextMeshProUGUI hedefpara_txt;
    void Start()
    {
        int simdikiLevel = SceneManager.GetActiveScene().buildIndex;
        hedefpara = (simdikiLevel * 200)+100;
        
        
        
        
        
        saniye_txt.text = "Saniye: "+saniye.ToString();
        para_txt.text = "Para: "+para.ToString();
        hedefpara_txt.text ="Hedef Para: "+hedefpara.ToString();
        InvokeRepeating("saniyeAzalt", 0.0f, 1.0f);
    }
   public void paraArttir(int deger)
    {
        para += deger;
        para_txt.text = "Para: " + para.ToString();
        if (para >= hedefpara)
        {
            sonrakiLevel();
        }
    }
    void sonrakiLevel()
    {
        sonrakilevel_panel.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void sonrakLevelButon()
    {
        int simdiki_level_no = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(simdiki_level_no);
    }








    void saniyeAzalt()
    {
        saniye--;
        saniye_txt.text = "Saniye: "+saniye.ToString();
        if (saniye <= 0)
        {
            kaybettin();
        }
    }
    void kaybettin()
    {
        kaybettin_panel.SetActive(true);
        Time.timeScale = 0.0f;
    }
   public void tekrarOynaButon()
    {
   
        Time.timeScale =1.0f;
        SceneManager.LoadScene(0);
    }
    public void cikisButon()
    {
        Application.Quit();
    }
    public void devamEtButon()
    {

        Time.timeScale = 1.0f;
        durdur_panel.SetActive(false);
    }
    public void durdurButon()
    {

        Time.timeScale = 0.0f;
        durdur_panel.SetActive(true);
    }
 
}
