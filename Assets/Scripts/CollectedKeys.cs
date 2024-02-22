using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedKeys : MonoBehaviour
{
    private List<int> keyList = new ();

    public void AddKey(int id)
    {
        keyList.Add(id);
    }
}

