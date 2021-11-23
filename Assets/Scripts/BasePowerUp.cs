using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePowerUp : MonoBehaviour
{
    //vars
    public char powerUpType;
    public int powerUpDuration;
    public float playerSpeedReduction;

    public virtual void ApplyPowerUp(){ //base method that additional things can be added later
        PlayerController.instance.PowerType = powerUpType;
        PlayerController.instance.Powered = true;
        StartCoroutine(StartPowerUp());
    }

    IEnumerator StartPowerUp(){
        Debug.Log("powerup start here");
        yield return new WaitForSeconds(1);
        PlayerController.instance.Powered = false;
        PlayerController.instance.PowerType = 'n';
        Debug.Log("powerup ended");
    }
}