using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatingBot : AIBot {

    // Tower Stats
    private static int HEALTH = 0, 
                        SPEED = 0, 
                        STRENGTH = 0;

    // Create a Duplicating Bot
    public DuplicatingBot() : base(HEALTH, SPEED, STRENGTH)
    {
        
    }

    // Creates regular bots on destroy
    void OnDestroy()
    {
        
    }
    
}
