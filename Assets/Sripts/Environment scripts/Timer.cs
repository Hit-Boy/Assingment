using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentTime;
    [SerializeField]
    private float startingTime;
    [SerializeField]
    Text timerText;

    [SerializeField]
    Text endText;



    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        
        StopGame();
        timerText.text = "Timer : " + currentTime.ToString("0");
    }

    private void StopGame()
    {
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0;
            endText.enabled = true;
        }
    
    }
}


