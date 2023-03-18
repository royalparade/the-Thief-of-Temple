using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour//加载场景，保存数据
{
    public void onclick()
    {
        List<cellclass> cellclass = new List<cellclass>();
        List<cell> cells_ = new List<cell>();
        switch (PlayerPrefs.GetInt("mapindex"))
        {
            case 1:
                cellclass = saver.instance.saveddata.cellclass1;
                saver.instance.saveddata.begin1position = valuebuider.instance.start.transform.position;
                saver.instance.saveddata.end1position = valuebuider.instance.end.transform.position;
                break;
            case 2:
                cellclass = saver.instance.saveddata.cellclass2;
                saver.instance.saveddata.begin2position = valuebuider.instance.start.transform.position;
                saver.instance.saveddata.end2position = valuebuider.instance.end.transform.position;
                break;
            case 3:
                cellclass = saver.instance.saveddata.cellclass3;
                saver.instance.saveddata.begin3position = valuebuider.instance.start.transform.position;
                saver.instance.saveddata.end3position = valuebuider.instance.end.transform.position;
                break;
            default:
                break;
        }

        cellclass.Clear();
        foreach (var cell in valuebuider.instance.cells)
        {
            cellclass.Add(new cellclass(cell.GetComponent<cell>().row, cell.GetComponent<cell>().line, cell.GetComponent<cell>().whatin,cell.GetComponent<cell>().direction));
        }
        
        saver.instance.save();
        SceneManager.LoadScene(2);
    }
}
