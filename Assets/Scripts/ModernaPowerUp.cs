using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModernaPowerUp : BasePowerUp
{
    //public vars
    public Button btnJump;

    //private vars
    private float originalSpeed;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            PlayerController.instance.CannotJump = false;
            btnJump.interactable = true;

            //show that the player has "collected" by making it disappear from view
            gameObject.transform.SetPositionAndRotation(new Vector2(100, 100), Quaternion.identity);
            ApplyPowerUp();

            GameObject[] des = GameObject.FindGameObjectsWithTag("Destory");
            foreach (GameObject i in des)
            {
                if (i != this.gameObject && i != null && i.gameObject.name != this.gameObject.name)
                {
                    Destroy(i);
                }
            }
        }
    }

    public override void ApplyPowerUp() {
        //setting powerup attributes (change duration and spd reduction as needed)
        PlayerController.instance.CurrentPower = PlayerController.PowerType.moderna;

        //12s because 1 week = 3s, vax lasts 4 weeks before rejabbing
        powerUpDuration = 12;
        PlayerController.instance.PowerUpDuration += powerUpDuration;

        playerSpeedReduction = 5;

        //saving original maxSpeed value
        originalSpeed = PlayerController.instance.maxSpeed;

        //affecting player's mobility
        if(PlayerController.instance.maxSpeed - playerSpeedReduction > 3) {
            PlayerController.instance.maxSpeed -= playerSpeedReduction;
        }
        else {
            PlayerController.instance.maxSpeed = 3;
        }

        //starting powerup
        StopAllCoroutines();
        base.ApplyPowerUp();
        StartCoroutine(AfterPowerUp());
    }

    IEnumerator AfterPowerUp() {
        //need this cause the code executes without waiting for ApplyPowerUp to finish
        yield return new WaitForSeconds(PlayerController.instance.PowerUpDuration);

        //returning player to unpowered state
        PlayerController.instance.maxSpeed = originalSpeed;
    }

    public override void Update() {
        base.Update();
    }
}