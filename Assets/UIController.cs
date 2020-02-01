using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public float splatterX;

    TMPro.TextMeshProUGUI score;
    public GameObject splatterPrefab;
    RectTransform objectRectTransform; 
    float uiWidth;
    float uiHeight;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        score.text = "";
        objectRectTransform = gameObject.GetComponent<RectTransform>();
        uiWidth = objectRectTransform.rect.width;
        uiHeight = objectRectTransform.rect.height;
        splatterX = 0f;
}

// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            addSplat();
        }
    }

    public void setScore(int points)
    {
        score.text = points.ToString();
    }

    public void addScore(int points)
    {
        int scr = int.Parse(score.text);
        scr = scr + points;
        score.text = scr.ToString();
    }

    public void addSplat()
    {
        float myX = Random.Range(0f, uiWidth);
        float myY = Random.Range(0f, uiHeight);
        float myRotate = Random.Range(0f, 360f);
        GameObject newsplat = Instantiate(splatterPrefab, new Vector3(myX, myY, 0), Quaternion.identity);
        newsplat.transform.SetParent(gameObject.transform,false);
        newsplat.transform.Rotate(0f, 0f, myRotate);
    }
}
