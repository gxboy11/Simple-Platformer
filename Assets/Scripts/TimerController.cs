using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    float remainingTime = 90.0F;

    float _elapsedTime;

    bool _isRemainingTime;

    private void Start()
    {
        _isRemainingTime = remainingTime > 0.0F;
    }

    private void Update()
    {
        if (_isRemainingTime)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0.0F)
            {
                remainingTime = 0.0F;
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
        }
        else
        {

            _elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_elapsedTime / 60);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60);
            timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
        }

    }
}
