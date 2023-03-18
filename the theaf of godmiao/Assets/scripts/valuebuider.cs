using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class valuebuider : MonoBehaviour
{
    public static valuebuider instance;

    public List<GameObject> cells = new List<GameObject>();
    public GameObject cell;

    public int putindex;
    public int direction;
    public GameObject whattoput;

    public GameObject stone;
    public GameObject ci;
    public GameObject plane;
    public GameObject arrowbuider;
    public GameObject spear;

    public GameObject start;
    public GameObject end;

    public GameObject projection;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = -8; i < 6; i++)
        {
            for (int j = -4; j < 5; j++)
            {
                GameObject tem = Instantiate(cell, new Vector2(i, j), Quaternion.identity);
                cells.Add(tem);
                tem.GetComponent<cell>().row = i;
                tem.GetComponent<cell>().line = j;
            }
        }
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = 2;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            direction = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = 3;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= 6.4f)
            {
                if (whattoput != null)
                {
                    cell temcell = getclostcell();
                    GameObject tem = Instantiate(whattoput, temcell.transform);
                    tem.transform.localPosition = new Vector2();
                    tem.transform.localEulerAngles = new Vector3(0,0,direction * 90f);
                    temcell.whatin = putindex;
                    temcell.direction = direction;
                }
            }
        }
        if (whattoput != null)
        {
            if (projection == null)
            {
                projection = Instantiate(whattoput, new Vector3(), Quaternion.identity);
            }
            projection.transform.localEulerAngles = new Vector3(0, 0, direction * 90f);
            projection.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        else
        {
            if (projection)
            {
                Destroy(projection);
            }
            projection = null;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            putindex = 10000;
            cell temcell = getclostcell();
            for (int i = temcell.transform.childCount - 1; i >= 0; i--)
            {                
                Destroy(temcell.transform.GetChild(i).gameObject);
            }
            temcell.whatin = 0;
            whattoput = null;
            putindex = 0;
        }
    }

    public void getbuttondown(int i)
    {
        putindex = i;
        direction = 0;
        if (projection)
        {
            Destroy(projection);
        }
        projection = null;
        switch (i)
        {
            case 1:
                whattoput = stone;
                break;
            case 2:
                whattoput = ci;
                break;
            case 3:
                whattoput = plane;
                break;
            case 4:
                whattoput = arrowbuider;
                break;
            case 5:
                whattoput = spear;
                break;
            case 6:
                SceneManager.LoadScene(0);
                break;
            default:
                break;
        }
    }

    public cell getclostcell()//返回离transform最近的没人的cell
    {
        cell temcell = null;

        float mindistance = 10000;

        Vector2 mousepo = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(Vector2.Distance(mousepo, new Vector2(cell.transform.position.x, cell.transform.position.y)));

        foreach (var cell in cells)
        {
            if (Vector2.Distance(mousepo, new Vector2(cell.transform.position.x, cell.transform.position.y)) <= mindistance)
            {
                if (cell.GetComponent<cell>().whatin != putindex)
                {
                    temcell = cell.GetComponent<cell>();
                    mindistance = Vector2.Distance(mousepo, new Vector2(cell.transform.position.x, cell.transform.position.y));
                }
            }
        }
        return temcell;
    }
}
