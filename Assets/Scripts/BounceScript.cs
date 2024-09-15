using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    private float startX;
    private float startY;

    private Rigidbody2D rb;


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
        Debug.Log("Update: ============== ");

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(transform.up * 500f);
        }

    }

    void FixedUpdate()
    {

        Debug.Log("FixedUpdate: +++++++++++++++++ ");


    }

    void OnCollisionEnter2D()
    {
        //rb.MovePosition(d);
        rb.AddForce(transform.up * 600f);
    }
}
