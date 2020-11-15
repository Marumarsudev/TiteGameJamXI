using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 10f;
    private float lifetimer = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") Destroy(this.gameObject);
    }

    private void Update() {
        lifetimer += Time.deltaTime;

        if (lifetimer >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
