
using System;
using UnityEngine;

public class CountDownInfo
{
    public float timeCountDown;
}

public class CountDownConditions : MonoBehaviour, ICondition
{
    private CountDownInfo      info;
    private float              countDown;
    private bool               isSuitable;
    private Action<ICondition> onSuitable;
    public object Info
    {
        set
        {
            info      = (CountDownInfo)value;
            countDown = info.timeCountDown;
        }
    }

    public bool               IsSuitable => isSuitable;
    public Action<ICondition> OnSuitable
    {
        set => onSuitable = value;
    }
    public void ResetCondition()
    {
        isSuitable = false;
        countDown  = info.timeCountDown;
    }

    private void Update()
    {
        if (countDown <= 0)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown <= 0)
        {
            isSuitable = true;
            onSuitable(this);
        }
    }
}