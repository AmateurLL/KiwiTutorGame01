using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_CharSpawn : MonoBehaviour
{
    public void SpawnChar(GameObject _char)
    {
        Vector3 charPosition = new Vector3(this.gameObject.transform.position.x,
                                                this.gameObject.transform.position.y,
                                                this.gameObject.transform.position.z);
        CSS_GameManager.Instance.playerRef =
            Instantiate(_char, charPosition, Quaternion.identity);
    }
}
