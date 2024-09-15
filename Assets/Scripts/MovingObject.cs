using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public virtual void OnBecameInvisible()
    {
       Destroy(gameObject);
    }


    // Update is called once per frame
    public void Update()
    {
        transform.Translate(-6f * Time.deltaTime, 0, 0);
    }
}
