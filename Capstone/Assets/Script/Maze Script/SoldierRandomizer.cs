using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoldierRandomizer : MonoBehaviour
{
    public Transform[] objects;
    public Transform[] boundary;
    public List<Vector2> points = new List<Vector2>();
    List<int> exclude = new List<int>();
    int listSize = 0;

    // Use this for initialization
    void Start()
    {
        listSize = points.Count();
        foreach (Transform t in objects)
        {
            GetRandomLocation();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    int ctr = 0;

    void GetRandomLocation()
    {
        int i = GetRandomNum();
        exclude.Add(i);
        objects[ctr].position = points[i];
        boundary[ctr].position = points[i];
        ctr++;
    }

    int GetRandomNum()
    {
        var range = Enumerable.Range(0, listSize).Where(o => !exclude.Contains(o));
        var rand = new System.Random();
        int index = rand.Next(0, listSize - 1 - exclude.Count);
        return range.ElementAt(index);
    }
}
