using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled = false;
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;
    private void Start()
    {
        allSlots = 40;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }
    private void Update()
    {
        //if I key get pressed, inventory will be showed
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled == true)
            {
                GameManager.instance.PauseWithoutMenu();
                inventory.SetActive(true);
            }
            else
            {
                GameManager.instance.ResumeGame();
                inventory.SetActive(false);
            }
        }
    }
}
