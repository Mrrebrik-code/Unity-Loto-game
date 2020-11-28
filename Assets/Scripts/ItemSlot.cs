using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public AudioClip Win;
    public AudioClip Magic;
    public AudioClip Helper;
    public AudioClip Pravilo;
    public int whon;
    public GameObject helperoshibka;
    public SoundManager soundPlay;
    PointerEventData eventData2;
    public ManagerGame manager;
    bool check2 = false;



    public delegate void onSlotTrue(int slot);
    public static event onSlotTrue onSlot;

    public void OnDrop(PointerEventData eventData)
    {
        
        Debug.Log("Hello");
        if (eventData.pointerDrag != null && (whon == eventData.pointerDrag.GetComponent<CheckSlots>().Who))
        {

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log(eventData.pointerDrag.gameObject.name);
            onSlot(1);
            eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;
        }
        else
        {
            manager.faill++;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<DragDrop>().xy;
            Debug.Log("Неверно!");
            helperoshibka.GetComponent<Animator>().SetBool("isHelperO", true);
            StartCoroutine(ActiveBurronMenu());

            if (manager.faill > 3 & manager.check2 == false)
            {
                soundPlay.PlaySound(Pravilo, 0.5f);
                manager.check2 = true;
                manager.faill = 0;
            }
            else
            {
                soundPlay.PlaySound(Helper, 0.5f);
            }
        }
    }

    IEnumerator ActiveBurronMenu()
    {
        yield return new WaitForSeconds(4f);
        helperoshibka.GetComponent<Animator>().SetBool("isHelperO", false);
    }
}
