using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BounceScript : MonoBehaviour
{
    private float startX;
    private float startY;

    private Rigidbody2D rb;


    public TMP_Text scoreText;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = rb.position.x;
        startY = rb.position.y;
    }

    // Update is called once per frame
    //  void Update()
    void Update()
    {
        // Debug.Log("Update: ============== ");

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(transform.up * 500f);
        }

    }

    void FixedUpdate()
    {

        // Debug.Log("FixedUpdate: +++++++++++++++++ ");


    }

    void OnCollisionEnter2D()
    {
        //rb.MovePosition(d);
        rb.AddForce(transform.up * 600f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.score++;
        scoreText.text = score.ToString();
        Debug.Log("trigger " + score);
    }
}
