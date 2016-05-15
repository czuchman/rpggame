﻿using UnityEngine;
using System.Collections;
public class PickUpItem : MonoBehaviour
{
    public Item item;
    private Inventory _inventory;
    private GameObject _player;
    // Use this for initialization

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
            _inventory = _player.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();
       // else Debug.Log("Inventory problemo!");
    } 

    void OnMouseDown()
    {
       // _player = GameObject.FindGameObjectWithTag("Player");
       // _inventory = _player.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();

       if (this._inventory != null)
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, _player.transform.position);

            if (distance <= 2)
        {
                bool check = _inventory.checkIfItemAllreadyExist(item.itemID, item.itemValue);
            if (check)
                Destroy(this.gameObject);
            else if (_inventory.ItemsInInventory.Count < (_inventory.width * _inventory.height))
            {
                _inventory.addItemToInventory(item.itemID, item.itemValue);
                _inventory.updateItemList();
                _inventory.stackableSettings();
                Destroy(this.gameObject);
            }
            
        }
             Debug.Log("Pickup doesn't work but I have no idea why...");
        }
}

    // Update is called once per frame
    void Update()
    {
       

    }


}