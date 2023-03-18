using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{
    public int row;
    public int line;
    public int whatin;
    public int direction;

    public cell()
    {
        
    }

    public cell Shallowcopy()
    {
        return (cell)MemberwiseClone();
    }
}
