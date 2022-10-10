using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStackController : MonoBehaviour
{
    public static BallStackController Instance { get; private set; }

    public List<GameObject> ballList;

    [SerializeField]
    private GameObject playerHand;

    [SerializeField]
    private GameObject ballPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        BallController.OnTriggeredBall += AddBall;
        BasketController.OnTriggeredBasket += RemoveBall;
    }

    private void OnDisable()
    {
        BallController.OnTriggeredBall -= AddBall;
        BasketController.OnTriggeredBasket -= RemoveBall;
    }


    public void AddBall()
    {
        GameObject newBall = Instantiate(ballPrefab, playerHand.transform.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody>().useGravity = false;
        newBall.GetComponent<MeshCollider>().isTrigger = true;
        ballList.Add(newBall);
        Destroy(newBall.GetComponent<BallController>());
        newBall.transform.SetParent(playerHand.transform);

        if (ballList.Count > 1)
        {
            newBall.transform.position = new Vector3(ballList[ballList.Count - 2].transform.position.x, ballList[ballList.Count - 2].transform.position.y + 2, ballList[ballList.Count - 2].transform.position.z);
        }
        else
        {
            newBall.transform.localPosition = new Vector3(0,0,0);
        }
    }

    public void RemoveBall(int maxBasketCapacity, int currentBallCount)
    {
        if (currentBallCount >= maxBasketCapacity)
        {
            for (int i = maxBasketCapacity; i > 0; i--)
            {
                Destroy(ballList[i]);
                ballList.Remove(ballList[i]);
            }
        }
        else
        {
            for (int i = currentBallCount - 1; i >= 0; i--)
            {
                Destroy(ballList[i]);
                ballList.Remove(ballList[i]);
            }
        }

        if (ballList.Count <= 0)
        {
            PlayerAnimationController.Instance.EndHoldBallsAnimation();
        }
    }

}
