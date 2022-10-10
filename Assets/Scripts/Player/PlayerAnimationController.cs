using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController Instance { get; private set; }

    [SerializeField]
    private Animator playerAnimator;

    public bool isMoving;
    public bool isHolding = false;

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
        BallController.OnTriggeredBall += StartHoldBallsAnimation;
        //isMoving = false;
        //isHolding = true;
        //BasketController.OnTriggeredBasket += EndHoldBallsAnimation;
    }

    private void OnDisable()
    {
        BallController.OnTriggeredBall -= StartHoldBallsAnimation;
        //isMoving = true;
        //isHolding = false;
        //BasketController.OnTriggeredBasket -= EndHoldBallsAnimation;
    }

    public void StartHoldBallsAnimation()
    {
        isMoving = false;
        isHolding = true;
        playerAnimator.SetBool("isHolding",true);
        playerAnimator.SetBool("isMoving", false);
    }

    public void EndHoldBallsAnimation()
    {
        isMoving = true;
        isHolding = false;
        playerAnimator.SetBool("isHolding", false);
        playerAnimator.SetBool("isMoving", true);
    }

    public void EndRunAnimation()
    {
        playerAnimator.SetBool("isMoving", false);
    }

    public void StartRunAnimation()
    {
        playerAnimator.SetBool("isMoving", true);
    }
}
