using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDamageCollision : MonoBehaviour
{
    [SerializeField] protected int _scoreDamage = 10;
    [SerializeField] protected ScoreCounter _scoreCounter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
            _scoreCounter._counter += _scoreDamage;
    }
}
