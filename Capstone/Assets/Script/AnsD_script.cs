using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class AnsD_script : MonoBehaviour
{

    List<string> questions = new List<string>() { "D. Courage, bravery, and honor" };

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
