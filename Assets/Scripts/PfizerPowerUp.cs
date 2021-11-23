using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfizerPowerUp : BasePowerUp
{
    private float originalSpeed;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            ApplyPowerUp();
            Destroy(gameObject);
        }
    }

    public override void ApplyPowerUp(){
        //setting powerup attributes
        powerUpType = 'p';
        powerUpDuration = 1;
        playerSpeedReduction = 15;

        //saving original maxSpeed value
        originalSpeed = PlayerController.instance.maxSpeed;

        //affecting player's mobility
        PlayerController.instance.maxSpeed -= playerSpeedReduction;
        PlayerController.instance.CannotJump = true;

        Debug.Log("aaa");
        //starting powerup
        base.ApplyPowerUp();
        StartCoroutine(Waiting(powerUpDuration));
    }

    IEnumerator Waiting(int i){
        yield return new WaitForSeconds(i);
        //after powerup
        PlayerController.instance.maxSpeed = originalSpeed;
        PlayerController.instance.CannotJump = false;
        Debug.Log("bbb");
    }
}
