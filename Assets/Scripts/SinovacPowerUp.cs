using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinovacPowerUp: BasePowerUp {

    //public vars
    public Button btnJump;

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
                if(i != this.gameObject && i != null && i.gameObject.name != this.gameObject.name)
                {
                    Destroy(i);
                }

                
            }

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

    public override void Update() {
        base.Update();
    }
}
