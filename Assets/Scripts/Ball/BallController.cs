using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public delegate void TriggerAction();
    public static event TriggerAction OnTriggeredBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnTriggeredBall != null)
            {
                    Debug.Log("Ball Collected!");
                    OnTriggeredBall();
                    Destroy(this.gameObject);
            }
        }
    }
}
