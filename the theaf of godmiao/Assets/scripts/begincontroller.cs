using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class begincontroller : MonoBehaviour
{
    public TMP_Text button1;
    public TMP_Text button2;
    public TMP_Text button3;


    private void Start()
    {
        if (saver.instance.saveddata.cellclass1.Count != 0)
        {
            button1.text = "点击挑战神庙";
        }
        else
        {
            button1.text = "空存档，点击建造神庙";
        }
        if (saver.instance.saveddata.cellclass2.Count != 0)
        {
            button2.text = "点击挑战神庙";
        }
        else
        {
            button2.text = "空存档，点击建造神庙";
        }
        if (saver.instance.saveddata.cellclass3.Count != 0)
        {
            button3.text = "点击挑战神庙";
        }
        else
        {
            button3.text = "空存档，点击建造神庙";
        }
    }

    public void onclick(int index)
    {
        switch (index)
        {
            case 1:
                if (saver.instance.saveddata.cellclass1.Count != 0)
                {
                    PlayerPrefs.SetInt("mapindex",1);
                    SceneManager.LoadScene(2);
                }
                else
                {
                    PlayerPrefs.SetInt("mapindex", 1);
                    SceneManager.LoadScene(1);
                }
                break;
            case 2:
                if (saver.instance.saveddata.cellclass2.Count != 0)
                {
                    PlayerPrefs.SetInt("mapindex", 2);
                    SceneManager.LoadScene(2);
                }
                else
                {
                    PlayerPrefs.SetInt("mapindex", 2);
                    SceneManager.LoadScene(1);
                }
                break;
            case 3:
                if (saver.instance.saveddata.cellclass3.Count != 0)
                {
                    PlayerPrefs.SetInt("mapindex", 3);
                    SceneManager.LoadScene(2);
                }
                else
                {
                    PlayerPrefs.SetInt("mapindex", 3);
                    SceneManager.LoadScene(1);
                }
                break;
            case 4:
                saver.instance.saveddata = new savegame();
                saver.instance.save();
                SceneManager.LoadScene(0);
                break;          
            default:
                break;
        }
    }
}
