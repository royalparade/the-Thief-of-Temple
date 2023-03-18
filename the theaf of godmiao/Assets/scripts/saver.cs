using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class saver : MonoBehaviour
{
    public static saver instance;
    public savegame saveddata;
    public bool hasload;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            load();
        }
    }

    public void save()
    {
        string datapath = Application.dataPath;
        var serializer = new XmlSerializer(typeof(savegame));
        var stream = new FileStream(datapath + "/" + saveddata.savename + ".save", FileMode.Create);
        serializer.Serialize(stream, saveddata);
        stream.Close();
        Debug.Log("saved");
    }

    public void load()
    {
        string datapath = Application.dataPath;
        if (System.IO.File.Exists(datapath + "/" + saveddata.savename + ".save"))
        {
            var serializer = new XmlSerializer(typeof(savegame));
            var stream = new FileStream(datapath + "/" + saveddata.savename + ".save", FileMode.Open);
            saveddata = serializer.Deserialize(stream) as savegame;
            stream.Close();
            hasload = true;
            Debug.Log("load");
        }
    }
}

[System.Serializable]
public class savegame
{
    public string savename = "save";
    public List<cellclass> cellclass1 = new List<cellclass>();
    public Vector2 begin1position;
    public Vector2 end1position;
    public List<cellclass> cellclass2 = new List<cellclass>();
    public Vector2 begin2position;
    public Vector2 end2position;
    public List<cellclass> cellclass3 = new List<cellclass>();
    public Vector2 begin3position;
    public Vector2 end3position;
}