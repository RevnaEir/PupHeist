using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedKeys : MonoBehaviour
{
    public List<int> keyList = new ();
    public List<Item> keyList2 = new ();

    private void Awake()
    {
        keyList2.Clear();
    }

    public void AddKey(int id)
    {
        keyList.Add(id);
    }
    public void AddKey(Item id)
    {
        keyList2.Add(id);
    }

    public int GetCount()
    {
        return keyList2.Count;
    }
}

