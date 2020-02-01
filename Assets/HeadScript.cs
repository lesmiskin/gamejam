using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    public float spin = 0f;
    public bool startSpinning = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(30f, 350f));
    }

    // Update is called once per frame
    void Update()
    {
        if(startSpinning) {
            this.transform.Rotate(0, 0, 1f);
        }
    }
}
