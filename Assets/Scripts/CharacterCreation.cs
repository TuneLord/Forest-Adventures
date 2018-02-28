using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour {

    private GameObject[] characterList;
    private int index;
    // Use this for initialization
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];

        for (int i=0; i< transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[index])
            characterList[index].SetActive(true);
    }

    // Update is called once per frame
    void Update ()
    {
      
    }
    public void MinkaCheck()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = 0;
        characterList[index].SetActive(true);
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Level1");
    }

    public void TuffikCheck()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
            index = 1;
        characterList[index].SetActive(true);

        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Level1");
    }

}
