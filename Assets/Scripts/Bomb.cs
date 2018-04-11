using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet {

    // when bullet hits AI
    public int blastRadius;

    protected override void OnHitAI(GameObject aIHit)
    {
        Camera.main.GetComponent<Level>().GetAllAIWithin(this.transform.position,this.blastRadius);
        Destroy(gameObject);
    }
   
}
