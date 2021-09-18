using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    public static int PlayerLayer;

    [SerializeField] private string playerLayerName;

    private void Awake()
    {
        PlayerLayer = LayerMask.NameToLayer(playerLayerName);
    }
}
