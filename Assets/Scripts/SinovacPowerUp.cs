using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinovacPowerUp: BasePowerUp {
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            //show that the player has "collected" by making it disappear from view
            gameObject.transform.SetPositionAndRotation(new Vector2(100, 100), Quaternion.identity);
            ApplyPowerUp();
        }
    }
    
    public override void ApplyPowerUp() {
        //setting powerup attributes (change duration and spd reduction as needed)
        PlayerController.instance.CurrentPower = PlayerController.PowerType.sinovac;

        //6s because 1 week = 2s, vax lasts 3 weeks before rejabbing (3-4 weeks, we assume the sooner)
        powerUpDuration = 6;
        PlayerController.instance.PowerUpDuration += powerUpDuration;

        //starting powerup
        StopAllCoroutines();
        base.ApplyPowerUp();
        StartCoroutine(AfterPowerUp());
    }

    IEnumerator AfterPowerUp() {
        //need this cause the code executes without waiting for ApplyPowerUp to finish
        yield return new WaitForSeconds(PlayerController.instance.PowerUpDuration);
    }
    public void Update()
    {
        if (powerUpDuration < 0)
        {
            durationText.gameObject.SetActive(false);
        }
        else
        {

            powerUpDuration -= Time.deltaTime;
            durationText.text = powerUpDuration.ToString("00");
            durationText.gameObject.SetActive(true);
        }
    }
}
