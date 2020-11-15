using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Player : MonoBehaviour
{

    private int selectedTrap = 0;

    private int trapsLeft = 3;
    public TextMeshProUGUI trapCount;
    public TextMeshProUGUI selectedTrapText;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
            {
                selectedTrap = 0;
                selectedTrapText.text = "Spikes";
            }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
            {
                selectedTrap = 1;
                selectedTrapText.text = "Bear trap";
            }
        if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedTrap = 2;
                selectedTrapText.text = "Rune";
            }

        if (Input.GetKeyDown(SETTINGS.useKey))
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1f, Vector2.zero, 0f);
            
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag == "Hole" && (trapsLeft > 0 || hits[i].collider.GetComponent<Hole>().isDug))
                {
                    if (!hits[i].collider.GetComponent<Hole>().isDug) trapsLeft--;
                    trapCount.text = "Traps left: " + trapsLeft.ToString();
                    hits[i].collider.GetComponent<Hole>().dig(selectedTrap);
                }
            }
        }

        if (Input.GetKeyDown(SETTINGS.secondaryUseKey))
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1f, Vector2.zero, 0f);
            
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag == "Hole" && hits[i].collider.GetComponent<Hole>().isDug)
                {
                    trapsLeft++;
                    trapCount.text = "Traps left: " + trapsLeft.ToString();
                    hits[i].collider.GetComponent<Hole>().reset();
                }
            }
        }
    }
}
