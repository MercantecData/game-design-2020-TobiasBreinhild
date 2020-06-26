using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    public float playerHealth;

    private Rigidbody2D rigidbody;

    public Image img1;

    public Image img2;

    public Image img3;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * inputX;
        position.y += speed * Time.deltaTime * inputY;

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win Zone")
        {
            SceneManager.LoadScene("WinScreen");
        }

        if (collision.tag == "Enemy")
        {
            playerHealth--;
        }

        if (playerHealth == 2)
        {
            img1.enabled = false;
        }

        if (playerHealth == 1)
        {
            img2.enabled = false;
        }

        if (playerHealth <= 0)
        {
            img3.enabled = false;
            SceneManager.LoadScene("EndScreen");
        }
    }
}
