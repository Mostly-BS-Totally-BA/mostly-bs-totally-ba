using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMovement : MonoBehaviour {

    public Transform player;
    private static GameManager _gm = null;

    private void LateUpdate()
    {
        _gm = GameManager.Instance;
        if (_gm.gameState == GameState.Game){
            Vector3 newPosition = player.position;
            newPosition.z = transform.position.z;
            transform.position = newPosition;            
        }
    }
}
