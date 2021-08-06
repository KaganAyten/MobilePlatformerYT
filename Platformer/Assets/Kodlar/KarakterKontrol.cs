using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    [SerializeField]
    private float hareketHizi;
    [SerializeField]
    [Range(150, 350)]
    private float ziplamaGucu;

    private Animator anim;
    private SpriteRenderer sRenderer;
    Rigidbody2D rb;
    int yon;
    bool ciftZiplayabilir;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
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
    bool YerdeMi()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, 1 << LayerMask.NameToLayer("Zemin"));
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void YonKarar(int fonksiyonYon)
    {
        this.yon = fonksiyonYon;
    }
    public void Ziplama()
    {
        if (ciftZiplayabilir == false)
        {
            if (YerdeMi())
            {
                Vector2 ziplamaVektoru = new Vector2(0, 1) * ziplamaGucu;
                rb.AddForce(ziplamaVektoru);
                anim.SetTrigger("ziplamak");
                ciftZiplayabilir = true;
            }
        }
        else if (ciftZiplayabilir == true)
        {
            Vector2 ziplamaVektoru = new Vector2(0, 1) * ziplamaGucu;
            rb.AddForce(ziplamaVektoru);
            anim.SetTrigger("ziplamak");
            ciftZiplayabilir = false;
        }
        


    }

}
