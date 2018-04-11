using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet {

    // when bullet hits AI
    public int blastRadius;

    protected override void OnHitAI(GameObject aIHit)
    {
        GameObject.FindGameObjectWithTag("Map").GetComponent<Level>().GetAllAiWithin(this.trasform.postion, this.blastRadius);

        Destroy(gameObject);
    }
   
}
