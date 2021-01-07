using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak : MonoBehaviour
{
    public int kecepatan;
    public int kekuatanlompat;
    public int pindah;
    public int heart;
    public int koin;
    public bool balik;
    public bool tanah;
    public bool Button_kiri;
    public bool Button_kanan;
    public bool Button_atas;
    public bool Button_bawah;
    public bool play_again;
    public float jangkauan;

    Text info_Heart;
    Text info_Coin;
    Vector2 play;
    Rigidbody2D lompat;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    Animator anim;
    public GameObject UI_Win, UI_Lose;

    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        play = transform.position;
        info_Heart = GameObject.Find("UI_Heart").GetComponent<Text>();
        info_Coin = GameObject.Find("UI_Coin").GetComponent<Text>();
    }

    void Update()
    {
        info_Heart.text = "Heart : " + heart.ToString();
        info_Coin.text = "Corn : " + koin.ToString();

        if(tanah == false)
        {
            anim.SetBool("lompat", true);
        }
        else
        {
            anim.SetBool("lompat", false);  
        }

        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);

        if (Input.GetKey (KeyCode.RightArrow) || (Button_kanan == true))
        {
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = -1;
            anim.SetBool("lari", true);
        }
        else if (Input.GetKey (KeyCode.LeftArrow) || (Button_kiri == true))
        {
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah = 1;
            anim.SetBool("lari", true);
        }
        else
        {
            anim.SetBool("lari", false);
        }

        if(tanah == true && Input.GetKey(KeyCode.X) || (Button_atas == true))
        {
            lompat.AddForce(new Vector2 (0, kekuatanlompat));
        }

        if(tanah == true && Input.GetKey(KeyCode.Z) || (Button_bawah == true))
        {
            anim.SetBool("slide", true);
        }
        else
        {
            anim.SetBool("slide", false);
        }

        if(pindah > 0 && !balik)
        {
            flip();
        }
        else if (pindah < 0 && balik)
        {
            flip();
        }

        if(heart <= 0)
        {
            Destroy(gameObject);
            UI_Lose.SetActive(true);
        }
        else if (koin >= 5 && tanah == true)
        {
            UI_Win.SetActive(true);
        }

        if(play_again == true)
        {
            transform.position = play;
            play_again = false;
        }
    }

    public void tekan_kiri()
    {
        Button_kiri = true;
    }
    
    public void Lepas_kiri()
    {
        Button_kiri = false;
    }
    
    public void tekan_kanan()
    {
        Button_kanan = true;
    }
    
    public void Lepas_kanan()
    {
        Button_kanan = false;
    }

    public void tekan_atas()
    {
        Button_atas = true;
    }
    
    public void Lepas_atas()
    {
        Button_atas = false;
    }

    public void tekan_bawah()
    {
        Button_bawah = true;
    }
    
    public void Lepas_bawah()
    {
        Button_bawah= false;
    }

    void flip()
    {
        balik = !balik;
        Vector3 Player = transform.localScale;
        Player.x *= -1;
        transform.localScale = Player;
    }
}
