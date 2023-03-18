using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * 1 * Time.deltaTime);
        // transform.Translate(Time.deltaTime*0.01f,);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "stone(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
