using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public delegate void TriggerAction(int maxBasketCapacity, int currentBallCount);
    public static event TriggerAction OnTriggeredBasket;

    public int maxBasketCapacity = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<BasketStackController>().PlaceBalls(maxBasketCapacity, BallStackController.Instance.ballList.Count);
            if (OnTriggeredBasket != null)
            {
                 OnTriggeredBasket(maxBasketCapacity, BallStackController.Instance.ballList.Count);
            }
        }
    }
}
