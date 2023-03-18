using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arrowbuider : MonoBehaviour
{
    public GameObject arrow;
    public int direction;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log(transform.rotation);
            StartCoroutine(shearrow());
        }
    }

    IEnumerator shearrow()
    {
        while (true)
        {
            GameObject TEM = null;
            TEM = Instantiate(arrow, transform.position, Quaternion.identity);
            TEM.transform.rotation = transform.rotation;
            yield return new WaitForSeconds(3f);
        }
    }
}
