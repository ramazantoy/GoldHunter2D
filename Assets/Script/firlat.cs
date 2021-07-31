using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firlat : MonoBehaviour
{
    public Rigidbody2D r;
    public Animator makara_animator;
    public float hiz;
    GameObject agiz;//Yakalama olursa agizda yer alacak nesne
    bool nesneVarmi = false;//yakalama var mi
    bool firlatmadurumu = false;// üst üste güç uygulamayı engellemek amacıyla

    public yonetici Yonet;
  
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "makara")// durumu başa sarma animasyonu tekrar başlatma
        {
            firlatmadurumu = false;
            r.velocity = Vector2.zero;
            makara_animator.enabled = true;
            if (nesneVarmi == true)
            {
              
                if (agiz.gameObject.tag == "altin")
                {
                    Destroy(agiz);
                    nesneVarmi = false;
                    Yonet.paraArttir(100);
                }
                if (agiz.gameObject.tag == "elmas")
                {
                    Destroy(agiz);
                    nesneVarmi = false;
                    Yonet.paraArttir(300);
                }
                if (agiz.gameObject.tag == "tas")
                {
                    Destroy(agiz);
                    nesneVarmi = false;
                    Yonet.paraArttir(-100);
                }
            }
        }
        if (collision.gameObject.tag == "altin" || collision.gameObject.tag == "elmas" || collision.gameObject.tag == "tas")// altın elmas veya tas
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            agiz = collision.gameObject;
            nesneVarmi = true;
            r.velocity = Vector2.zero;
            r.AddForce(transform.up * hiz);
            collision.gameObject.transform.parent = transform;
        }
    
    }


    void Update()
    {
 
        
    }
   
    public void firlatma()
    {
        if (firlatmadurumu == false)
        {
            makara_animator.enabled = false;
            r.AddForce(-transform.up * hiz);
            firlatmadurumu = true;

        }
 
    }
    private void OnBecameInvisible()//geri dönme ekran dışına çıakrsa
    {
        r.velocity = Vector2.zero;
        r.AddForce(transform.up * hiz);
    }
}
