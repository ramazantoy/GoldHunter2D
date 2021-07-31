using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makara : MonoBehaviour
{
    public LineRenderer ip;
    public Transform kanca;
    void Update()
    {
        ip.SetPosition(0, transform.position);//makaranın pozisyonu
        ip.SetPosition(1, kanca.position);//kancanın pozisyonu
        
    }
}
