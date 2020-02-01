using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeController : MonoBehaviour
{
    // GAMEPLAY
    // ========
    public static int score_cuts = 0;
    public static int score_hits = 0;
    public static int cut_limit = 3;
    public static int hit_limit = 3;


    bool isSwiping = false;
    float swipeProgress = 0;
    Animator animator;

    public float swipeSpeed = 5f;
    public float swipeDistance = 200f;
    public float originX = 0;

    public float axeYPos = 0;
    public float axeYSize = 0;


    // // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public float demoHairPos = 0;
    public float demoAxePos = 0;
    public bool dead = false;

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
                animator.SetTrigger("doSwipe");
                CutHair();
            }
        }

        var hair = GameObject.Find("/man/hair");
        var axe = GameObject.Find("/deathMain/scythe_pivot/scythe");

        var hairPosTop = (hair.transform.position.y + (hair.GetComponent<Renderer>().bounds.size.y/2));
        var hairPosBottom = (hair.transform.position.y - (hair.GetComponent<Renderer>().bounds.size.y/2));
        var axePos = (axe.transform.position.y);

        demoHairPos = hairPosTop;
        demoAxePos = axePos;
    }

    void CutHair() {
        var hair = GameObject.Find("/man/hair");
        var axe = GameObject.Find("/deathMain/scythe_pivot/scythe");
        var hairPosTop = (hair.transform.position.y + (hair.GetComponent<Renderer>().bounds.size.y/2));
        var hairPosBottom = (hair.transform.position.y - (hair.GetComponent<Renderer>().bounds.size.y/2));
        var axePos = (axe.transform.position.y);

        // demoHairPos = hairPos;
        // demoAxePos = axePos;
        // 2.9 (axe is quite high)
        // 0.1 (hair is low)

        // hit head.
        if(axePos < hairPosBottom) {
            dead = true;
            doHit();
            return;
        }

        var haircutAmount = hairPosTop - axePos;
        haircutAmount /= 10;

        //var fullHeight = 0.009999998;

        // If in cutting range
        if(axePos < hairPosTop) {
            hair.transform.localScale -= new Vector3(0, haircutAmount, 0);
            hair.transform.position -= new Vector3(0, haircutAmount, 0);
            doCut();

            // if(hair.transform.localScale.y < 0) {
            //     // TODO: BEHEAD
            //     hair.transform.localScale = new Vector3(0, 0.01f, 0);
            // }

            // hair.transform.localScale -= new Vector3(0,0.1f,0);
            // hair.transform.position -= new Vector3(0,0.1f,0);
        }
    }

    void doHit() {
        // Too many hits? Fatality!
        if(score_hits+1 == hit_limit) {
            var torso = GameObject.Find("behead_torso");
            var head = GameObject.Find("behead_head");

            torso.GetComponent<Rigidbody2D>().constraints = 0;

//            SceneManager.LoadScene("end_bad", LoadSceneMode.Additive);        
            return;
        }
        score_hits++;
    }

    void doCut() {
        // Reached no. of cuts? show good ending screen.
        if(score_cuts+1 == cut_limit) {
            SceneManager.LoadScene("end_good", LoadSceneMode.Additive);        
            return;
        }
        score_cuts++;
    }

    void FixedUpdate()
    {
        // OLD CODE FOR LINEAR SCYTHE MOVEMENT.

        // Vector3 movement = new Vector3(
        //     swipeProgress, 
        //     0,
        //     0
        // );
        // movement *= Time.deltaTime;

        // Vector3 movement2 = new Vector3(
        //     originX + movement.x,                             // only apply adjustment to X axis.
        //     0, 
        //     transform.position.z
        // );

        // // Absolute position
        // transform.position = movement2;
    }
}
