using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{

    public GameObject my_marble;
    Marble my_marble_script;

    // Start is called before the first frame update
    void Start()
    {
        my_marble_script = my_marble.GetComponent<Marble>(); 
    }

    // Update is called once per frame
    void Update()
    {
        my_marble_script.x = 5;
    }
}
