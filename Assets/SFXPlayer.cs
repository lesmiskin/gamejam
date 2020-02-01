using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    AudioSource audioSource;
    public string playSfx;
    public bool play;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playSfx = "ScytheCut";
        play = false;
        delay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (play || Input.GetKeyDown(KeyCode.Space) )
        {
            playSound(playSfx, delay);
            play = false;
        }
    }

    void playSound(string sfx, float delay)
    {
        //float numF = Random.Range(1f, 4f);
        int scytheAttackNumber = Mathf.FloorToInt(Random.Range(1f, 4f));
        if (sfx != "")
        {
            audioSource.clip = Resources.Load<AudioClip>(sfx+scytheAttackNumber);
            audioSource.PlayDelayed(delay);
        }

    }

}
