using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Yeni Obje", menuName = "Taşınabilir Obje Oluştur")]
public class Pickable : ScriptableObject
{
    public Transform koyulacagiYer;
    public Vector3 koyulacagiHedef;
    public GameObject spawnObject;
    public GameObject inGameObject;
}
