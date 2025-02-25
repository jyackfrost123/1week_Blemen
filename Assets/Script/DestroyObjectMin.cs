using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectMin : MonoBehaviour
{
    private GameObject camera;

    private float mergen;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        mergen = this.transform.position.y + 10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( mergen < camera.transform.position.y )
        {
            Destroy(this.gameObject);
        }
    }
}
