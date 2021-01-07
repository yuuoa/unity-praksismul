using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGator : MonoBehaviour
{
    gerak KomponenGerak;

    void Start()
    {
        KomponenGerak = GameObject.Find("Player").GetComponent<gerak>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            KomponenGerak.heart = KomponenGerak.heart-2;
        }
        KomponenGerak.play_again = true;
    }
}
