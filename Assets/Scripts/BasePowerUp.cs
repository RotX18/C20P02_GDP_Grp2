using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePowerUp : MonoBehaviour
{
    //BASE CLASS FOR POWERUPS
    //vars
    [HideInInspector] public float powerUpDuration;
    [HideInInspector] public float playerSpeedReduction;
    public Text durationText;

    public virtual void ApplyPowerUp(){ //base method that additional things can be added later
        PlayerController.instance.Powered = true;
        StartCoroutine(StartPowerUp());
    }

    IEnumerator StartPowerUp(){
        //start of powerup
        yield return new WaitForSeconds(PlayerController.instance.PowerUpDuration);

        //when powerup ends
        PlayerController.instance.Powered = false;
        PlayerController.instance.CurrentPower = PlayerController.PowerType.none;
        Destroy(gameObject, PlayerController.instance.PowerUpDuration);
    }
}