using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectCharacter;
    public Character[] characters;

    public Button unlockedButton;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        selectCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach(GameObject player in skins)
        {
            player.SetActive(false);
        }
        skins[selectCharacter].SetActive(true);

        foreach(Character ch in characters)
        {
            if (ch.price == 0)
            {
                ch.isUnLocked = true;
            }
            else
            {
                
                ch.isUnLocked = PlayerPrefs.GetInt(ch.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
    }

    public void NextButton()
    {
        skins[selectCharacter].SetActive(false);
        selectCharacter++;
        if (selectCharacter == skins.Length)
        {
            selectCharacter = 0;
        }
        skins[selectCharacter].SetActive(true);
        if (characters[selectCharacter].isUnLocked)
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectCharacter);

        }
        UpdateUI();
    }
    public void PrevButton()
    {
        skins[selectCharacter].SetActive(false);
        selectCharacter--;
        if (selectCharacter == -1)
        {
            selectCharacter = skins.Length-1;
        }
        skins[selectCharacter].SetActive(true);
        if (characters[selectCharacter].isUnLocked)
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectCharacter);

        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinText.text = " " + PlayerPrefs.GetInt("NumberOfCoins", 0);
        if (characters[selectCharacter].isUnLocked)
        {
            unlockedButton.gameObject.SetActive(false);
        }
        else
        {
            unlockedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price :" + characters[selectCharacter].price;
            if (PlayerPrefs.GetInt("NumberOfCoins", 0) < characters[selectCharacter].price)
            {
                unlockedButton.gameObject.SetActive(true);
                unlockedButton.interactable = false;
            }
            else
            {
                unlockedButton.gameObject.SetActive(true);
                unlockedButton.interactable = true;
            }
        }
    }

    public void UnlockCharacter()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = characters[selectCharacter].price;

        PlayerPrefs.SetInt("NumberOfCoins", coins - price);

        PlayerPrefs.SetInt(characters[selectCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectCharacter);
        characters[selectCharacter].isUnLocked = true;
        UpdateUI();
    }
}
