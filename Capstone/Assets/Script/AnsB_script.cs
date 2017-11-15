using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class AnsB_script : MonoBehaviour
{

    List<string> questions = new List<string>() { "B. Luzon, Visayas, and Mindanao" };

    // Use this for initialization
    void Start()
    {
        GetComponent<TextMesh>().text = questions[0];

    }

    // Update is called once per frame
    void Update()
    {

    }
}
