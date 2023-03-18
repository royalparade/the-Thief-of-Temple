using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "arrow(Clone)")
        {
            Destroy(collision.gameObject);
        }
  
    }
}
