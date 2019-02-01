using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlitzMeter : MonoBehaviour
{
    private float meterAmount;
    public float MeterAmount {
        get{return Mathf.CeilToInt(meterAmount);}
    }
    public Timer blitzTimer;
    public bool active;
    public Image meterFill;

    public void BeginInvoke(){
        InvokeRepeating("Subtract5",0,1);
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void StopInvoke()
    {
        CancelInvoke();
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    void Update(){
        UpdateMeter();
    }

    private void UpdateMeter(){
        meterFill.fillAmount = Map(meterAmount, 100f);
    }

    private float Map(float value, float maxValue){
        return value / maxValue;
    }

    public void AddMeter(float amount){
        meterAmount += amount;
        if(meterAmount > 100) meterAmount = 100;
    }

    public void SubtractMeter(float amount){
        meterAmount -= amount;
        if(meterAmount < 0) meterAmount = 0;
    }

    void Subtract5()
    {
        meterAmount -= 5;
        if (meterAmount < 0) meterAmount = 0;
    }
}
