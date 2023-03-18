using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapbuider : MonoBehaviour
{
    public List<GameObject> cells = new List<GameObject>();

    public GameObject stone;
    public GameObject ci;
    public GameObject plane;
    public GameObject arrowbuider;
    public GameObject spear;
    public GameObject player;


    public GameObject start;
    public GameObject end;

    private void Start()
    {
        List<cellclass> tem = new List<cellclass>();
        switch (PlayerPrefs.GetInt("mapindex"))
        {
            case 1:
                tem = saver.instance.saveddata.cellclass1;
                start.transform.position = saver.instance.saveddata.begin1position;
                end.transform.position = saver.instance.saveddata.end1position;
                break;
            case 2:
                tem = saver.instance.saveddata.cellclass2;
                start.transform.position = saver.instance.saveddata.begin2position;
                end.transform.position = saver.instance.saveddata.end2position;
                break;
            case 3:
                tem = saver.instance.saveddata.cellclass3;
                start.transform.position = saver.instance.saveddata.begin3position;
                end.transform.position = saver.instance.saveddata.end3position;
                break;
            default:
                break;
        }
        player.transform.position = start.transform.position;
        foreach (var cell in tem)
        {
            GameObject temcell = null;
            switch (cell.whatin)
            {
                case 1:
                    temcell = Instantiate(stone, new Vector2(cell.row, cell.line), Quaternion.identity);
                    temcell.transform.localEulerAngles = new Vector3(0, 0, cell.direction * 90f);
                    break;
                case 2:
                    temcell = Instantiate(ci, new Vector2(cell.row, cell.line), Quaternion.identity);
                    temcell.transform.localEulerAngles = new Vector3(0, 0, cell.direction * 90f);
                    break;
                case 3:
                    temcell = Instantiate(plane, new Vector2(cell.row, cell.line), Quaternion.identity);
                    temcell.transform.localEulerAngles = new Vector3(0, 0, cell.direction * 90f);
                    break;
                case 4:
                    temcell = Instantiate(arrowbuider, new Vector2(cell.row, cell.line), Quaternion.identity);
                    temcell.transform.localEulerAngles = new Vector3(0, 0, cell.direction * 90f);
                    temcell.GetComponent<arrowbuider>().direction = cell.direction;
                    break;
                case 5:
                    temcell = Instantiate(spear, new Vector2(cell.row, cell.line), Quaternion.identity);
                    temcell.transform.localEulerAngles = new Vector3(0, 0, cell.direction * 90f);
                    break;
                default:
                    break;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }
}
