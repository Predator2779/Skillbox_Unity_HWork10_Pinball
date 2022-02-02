using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDamageTrigger : ScoreDamageCollision
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 3)
            _scoreCounter._counter += _scoreDamage;
    }
}
