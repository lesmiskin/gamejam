using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetKeyDown("space")) {
            SceneManager.LoadScene("title", LoadSceneMode.Single);        
            SwipeController.score_cuts = 0;
            SwipeController.score_hits = 0;
        }
    }
}
