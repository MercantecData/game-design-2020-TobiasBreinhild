using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHP;
    public Animator anim;

    public bool gotHitByBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gotHitByBullet == true)
        {
            anim.SetBool("gotHit", true);
        }
        else if(gotHitByBullet == false)
        {
            anim.SetBool("gotHit", false);
        }

        if(enemyHP <= 0)
        {
            Invoke("DestroyStuff", 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeathSound");
            GotHitTrue();
            enemyHP -= 1;
            Invoke("GotHitFalse", 1f);
        }
    }

    void GotHitTrue()
    {
        gotHitByBullet = true;
    }

    void GotHitFalse()
    {
        gotHitByBullet = false;
    }

    void DestroyStuff()
    {
        Destroy(gameObject);
    }
}
