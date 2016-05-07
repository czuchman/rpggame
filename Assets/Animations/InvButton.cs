using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InvButton : MonoBehaviour {

    public GameObject inventory;
    private Inventory mainInventory;

  
public void OpenINV()
    {
        mainInventory = inventory.GetComponent<Inventory>();
        mainInventory.openInventory();
    }
}
