using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    [SerializeField]
    private float hareketHizi;

    private Animator anim;
    private SpriteRenderer sRenderer;
    int yon;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.Translate(yon * hareketHizi * Time.deltaTime, 0, 0);
        if (yon != 0)
        {
            anim.SetBool("kosuyor", true);
            if (yon > 0)
            {
                sRenderer.flipX = false;
            }
            else if (yon < 0)
            {
                sRenderer.flipX = true;

            }
        }
        else
        {

            anim.SetBool("kosuyor", false);
        }
    }
    public void YonKarar(int fonksiyonYon)
    {
        this.yon = fonksiyonYon;
    }

}
