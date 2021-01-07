using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
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
            KomponenGerak.heart--;
        }
        KomponenGerak.play_again = true;
    }
}
