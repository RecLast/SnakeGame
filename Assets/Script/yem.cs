using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yem : MonoBehaviour
{

    public TMPro.TextMeshProUGUI yazi_txt;
    public TMPro.TextMeshProUGUI skor_txt;

    int skor = 0;
    int artis_degeri = 100;

    void Start()
    {
        InvokeRepeating("kontrol", 0, 5.0f); 
    }

    void kontrol()
    {
        float X = Random.Range(0.50f, 5.0f);
        float Z = Random.Range(0.0f, 5.2f);

        int rastgele = Random.Range(1, 5);

        if(rastgele == 4)
        {
            yazi_txt.gameObject.SetActive(true);
        }
        else
        {
            yazi_txt.gameObject.SetActive(false);
        }

        Vector3 koordinat = new Vector3(X, 0, Z);
        transform.position = koordinat;
    }

    private void OnTriggerEnter(Collider nesne)
    {
        if (nesne.gameObject.tag == "Player")
        {
            CancelInvoke();
            InvokeRepeating("kontrol", 0f, 5.0f);
            if(yazi_txt.gameObject.activeSelf == true)
            {
                skor += (artis_degeri * 2);
            }
            else
            {
                skor += artis_degeri;
            }
            skor_txt.text = "Skor : " + skor;
        }
        if(nesne.gameObject.tag =="kuyruk")
        {
            CancelInvoke();
            InvokeRepeating("kontrol", 0f, 5.0f);
        }
    }
}
