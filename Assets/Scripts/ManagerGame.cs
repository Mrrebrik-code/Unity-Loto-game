using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    int puzzle = 0;
    public int faill = 0;
    public bool check2 = false;
    public GameObject menuWin;
    public SoundManager sound;
    public AudioClip clipWin;
    bool check = false;
    public GameObject Win;

    private void Start()
    {
        ItemSlot.onSlot += Wins;
    }

    void Wins(int slot)
    {
        puzzle += slot;
    }

    private void Update()
    {
        if(puzzle == 7 && check == false)
        {
            StartCoroutine(ActiveBurronMenu2());
            check = true;
        }
    }

    public void ButtonContinue()
    {
        SceneManager.LoadScene("Levl" + (SceneManager.GetActiveScene().buildIndex + 2));
    }

    public void ButtonReplace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }


    IEnumerator ActiveBurronMenu2()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
        sound.PlaySound(clipWin, 1f);
        menuWin.SetActive(true);
        Win.GetComponent<Animator>().SetBool("isWin", true);
    }
}
