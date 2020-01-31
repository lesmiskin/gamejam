using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool isSwiping = false;
    float swipeProgress = 0;

    public float swipeSpeed = 5f;
    public float swipeDistance = 200f;

    public float originX = 0;

    // Update is called once per frame
    void Update()
    {
        bool keyPressed = UnityEngine.Input.GetKeyDown("space");

        if(keyPressed) {
            isSwiping = true;
        }

        if(isSwiping) {
            swipeProgress += swipeSpeed;
            if(swipeProgress > swipeDistance) {
                isSwiping = false;
                swipeProgress = 0;
                CutHair();
            }
        }

    }

    public float demoHairPos = 0;
    public float demoAxePos = 0;
    public float axeYPos = 0;
    public float axeYSize = 0;

    void CutHair() {
        var hair = GameObject.Find("/man/hair");
        var hairPos = (hair.transform.position.y + (hair.GetComponent<Renderer>().bounds.size.y/2));
        var axePos = (transform.position.y - ((GetComponent<Renderer>().bounds.size.y/2)));

        // demoHairPos = hairPos;
        // demoAxePos = axePos;
        // 2.9 (axe is quite high)
        // 0.1 (hair is low)

        var haircutAmount = hairPos - axePos;

        // If in cutting range
        if(axePos < hairPos) {
            hair.transform.localScale -= new Vector3(0, haircutAmount, 0);
            hair.transform.position -= new Vector3(0, haircutAmount, 0);

            // if(hair.transform.localScale.y < 0) {
            //     hair.transform.localScale = new Vector3(0, 0.01f, 0);
            // }

            // hair.transform.localScale -= new Vector3(0,0.1f,0);
            // hair.transform.position -= new Vector3(0,0.1f,0);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            swipeProgress, 
            0,
            0
        );
        movement *= Time.deltaTime;

        Vector3 movement2 = new Vector3(
            originX + movement.x,                             // only apply adjustment to X axis.
            0, 
            transform.position.z
        );

        // Absolute position
        transform.position = movement2;
    }
}
