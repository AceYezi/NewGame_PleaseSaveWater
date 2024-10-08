using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningControl : MonoBehaviour
{
    private const string IS_FLICKER="isFlicker";

   [SerializeField] private GameObject warningUI;
   //[SerializeField] private Animator progressBarAnimator;

    public static WarningControl Instance  { get; private set; }
    private float warningSoundRate = 0.2f;
    private float warningSoundTimer = 0;

    private bool isWarning = false;

    private void Update()
    {
        if(isWarning)
        {
            warningSoundTimer += Time.deltaTime;
            if(warningSoundTimer>warningSoundRate)
            {
                warningSoundTimer = 0;
                SoundManager.Instance.PlayWarningSound();
            }
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    public void ShowWarning()
    {
        if(isWarning==false)
        {
            isWarning = true;
            warningUI.SetActive(true);
           // progressBarAnimator.SetBool(IS_FLICKER,true);
        }

    }

    public void StopWarning()
    {
        isWarning = false;
        warningUI.SetActive(false);
        //progressBarAnimator.SetBool(IS_FLICKER, false);
    }
}
