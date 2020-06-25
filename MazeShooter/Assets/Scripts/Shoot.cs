using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().Play("PlayerShoot");
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = bullet.transform.up * 3;

            Destroy(bullet, 5);
        }


    }
}
