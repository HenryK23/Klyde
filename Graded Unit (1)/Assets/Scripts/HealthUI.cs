
using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{

    public Health health;
    public int numofHearts;

    public Text ScoreText;
    public int score;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Text TimerText;
    private float Timer;
    private int TimerR;




    private void Start()
    {
        Timer = 0;
    }

    void Update()
    {
        score = health.score;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health.health)
            {
                hearts[i].sprite = fullHeart;

            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numofHearts)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    
        Timer++;
        // Debug.Log(Timer);
        if (Timer % 100 == 0)
        {
            TimerR++;
            //Debug.Log(TimerR);
        }
        TimerText.text = TimerR.ToString();

        ScoreText.text = score.ToString();


    }
}