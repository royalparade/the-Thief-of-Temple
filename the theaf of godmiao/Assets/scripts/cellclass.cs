using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class cellclass
{
    public int row;
    public int line;
    public int whatin;
    public int direction;

    public cellclass()
    {

    }

    public cellclass(int row_,int line_, int whatin_,int direnction_)
    {
        line = line_;
        row = row_;
        whatin = whatin_;
        direction = direnction_;
    }
}
