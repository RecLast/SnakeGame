using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hareket : MonoBehaviour
{
    public GameObject kuyruk;

    List<GameObject> kuyruklar;
    Vector3 eski_pozisyon;
    GameObject cikarilan_kuyruk;

    float hiz = 50.0f;

    private void OnTriggerEnter(Collider nesne)
    {
        if (nesne.gameObject.tag == "yem")
        {
            GameObject yeni_kuyruk = Instantiate(kuyruk, eski_pozisyon, Quaternion.identity);
            kuyruklar.Add(yeni_kuyruk);
        }
        if(nesne.gameObject.tag =="kuyruk1" || nesne.gameObject.tag=="duvar")
        {
            SceneManager.LoadScene("Scenes/Level");
        }
        
    }
    void Start()
    {
        kuyruklar = new List<GameObject>();
        for (int i = 0; i <= 3; i++)
        {
            GameObject yeni_kuyruk = Instantiate(kuyruk, eski_pozisyon, Quaternion.identity);
            kuyruklar.Add(yeni_kuyruk);
        }
        InvokeRepeating("hareket_et", 0, 0.070f);
    }

    void hareket_et()
    {
        transform.Translate(0, 0, hiz * Time.deltaTime);
        eski_pozisyon = transform.position;


        if (kuyruklar.Count > 0)
        {
            kuyruklar[0].transform.position = eski_pozisyon;

            cikarilan_kuyruk = kuyruklar[0];
            kuyruklar.RemoveAt(0);
            kuyruklar.Add(cikarilan_kuyruk);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0,-90, 0);
        }
    }
}
