using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeTimeManager : MonoBehaviour
{
    private float loopTime = 1;

    public float totalTime = 30;

    void Start()
    {
        AdjustTime();
    }

    void AdjustTime()
    {
        if (totalTime <= 0)
        {
            if (UIController.Instance.AIColor == Color.red)
            {
                UIController.Instance.ShowFailScreen();
            }
            else
            {
                UIController.Instance.ShowSuccessScreen();
            }
        }
        else
        {
            if (UIController.Instance.AIColor == Color.red)
            {
                UIController.Instance.ShowFailScreen();
            }
            else
            {
                totalTime -= 1;
                UIController.Instance.ShowRemainTime(totalTime);
            }
        }
        Invoke("AdjustTime", loopTime);
    }
}
