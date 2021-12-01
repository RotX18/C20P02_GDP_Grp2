using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PfizerPowerUp : BasePowerUp
{
    public Button btnJump;
    private float originalSpeed;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            //show that the player has "collected" by making it disappear from view
            gameObject.transform.SetPositionAndRotation(new Vector2(100, 100), Quaternion.identity);
            btnJump.interactable = false;
            ApplyPowerUp();
        }
    }

    public override void ApplyPowerUp(){
        //setting powerup attributes (change duration and spd reduction as needed)
        PlayerController.instance.CurrentPower = PlayerController.PowerType.pfizer;

        //8s because 1 weeek = 2s, vax lasts 4 weeks before rejabbing
        powerUpDuration = 8;
        PlayerController.instance.PowerUpDuration += powerUpDuration;

        playerSpeedReduction = 7;

        //saving original maxSpeed value
        originalSpeed = PlayerController.instance.maxSpeed;

        //affecting player's mobility
        PlayerController.instance.maxSpeed -= playerSpeedReduction;
        PlayerController.instance.CannotJump = true;

        //starting powerup
        StopAllCoroutines();
        base.ApplyPowerUp();
        StartCoroutine(AfterPowerUp());
    }

    IEnumerator AfterPowerUp(){
        //need this cause the code executes without waiting for ApplyPowerUp to finish
        yield return new WaitForSeconds(PlayerController.instance.PowerUpDuration);

        //returning player to unpowered state
        PlayerController.instance.maxSpeed = originalSpeed;
        PlayerController.instance.CannotJump = false;

        //reenabling jump button
        btnJump.interactable = true;
    }
}
