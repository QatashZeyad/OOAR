using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet {

    // when bullet hits AI
    public int blastRadius;

    protected override void OnHitAI(GameObject aIHit)
    {
        GameObject[] bots = GameObject.FindGameObjectWithTag("Map").GetComponent<Level>().GetAllAIWithin(this.trasform.postion, this.blastRadius);
        foreach (GameObject bot in bots)
            bot.GetComponent<AIBot>().Hurt(this.strength);
        Destroy(gameObject);
    }
   
}
