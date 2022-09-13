using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPiece : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, transform.forward * 300, 0.01f, LayerMask.GetMask("Cannes"));
        //+if(hit.collider.gameObject != null && //비어져 있는 칸일때)
    }
}
