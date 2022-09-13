using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text SCORE;
    public Image[] customImage;

    public static int score = 0;
    public static int life = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 2)
        {
            customImage[0].gameObject.SetActive(false);
        }

        else if(life == 1)
        {
            customImage[1].gameObject.SetActive(false);
        }

        else if(life == 0)
        {
            customImage[2].gameObject.SetActive(false);
        }

        else if(life < 0 )
        {
            customImage[3].gameObject.SetActive(true);

            Invoke("TimeFreeze" , 2.5f);
        }

        SCORE.text = score.ToString();
    }

    void TimeFreeze()
    {
        Time.timeScale = 0;
    }
}
