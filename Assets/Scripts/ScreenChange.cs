using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChange : MonoBehaviour
{
    public int GameMode = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetKeyDown("space")) {
            // Start the game.
            // if(GameMode == 0) {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);        
                GameMode = 1;

            // Loop back to the start of the game.
            // } else if(GameMode == 1) {
                // SceneManager.LoadScene("title", LoadSceneMode.Single);        
                // GameMode = 0;
            // }
        }
    }
}
