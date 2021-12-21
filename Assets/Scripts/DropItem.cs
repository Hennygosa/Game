using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject item;
    public int chance;

    public DropItem(GameObject _item, int _chance)
    {
        item = _item;
        chance = _chance;
    }

    public void CreateDropItem(Vector3 position)
    {
        Instantiate(item, position, Quaternion.Euler(0, 90, 90));
    }
}