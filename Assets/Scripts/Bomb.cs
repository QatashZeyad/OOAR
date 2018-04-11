using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet {

    // when bullet hits AI
    public int blastRadius;

    protected override void OnHitAI(GameObject aIHit)
    {
<<<<<<< HEAD
        GameObject.FindGameObjectWithTag("Map").GetComponent<Level>().GetAllAiWithin(this.trasform.postion, this.blastRadius);

=======
        Camera.main.GetComponent<Level>().GetAllAIWithin(this.transform.position,this.blastRadius);
>>>>>>> 1b0f3794a631ac33a0a05fbc79897822bdb94b75
        Destroy(gameObject);
    }
   
}
