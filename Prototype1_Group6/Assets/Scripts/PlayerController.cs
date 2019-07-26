﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] underscorePrefabArr; //Store the underscore prefabs here. Methods will display a random one.
    public GameObject[] alphabetPrefabArr; //Store the alphabet prefabs here. Methods will display them as needed.

    string playerTextInput = ""; //Stores the current typed input from the player. Is cleared on a new word.
    string cloudWord = ""; //The word of the cloud; the desired answer to get
    bool isTypingActive = true; //Whether or not the player is allowed to type. Disabled when no word is currently present.

    float horizontalLevelSpace = 18; //The screen size in units. Currently unused.

    GameObject[] underscoreArray = new GameObject[10]; //The gameobject array that VISUALLY displays the underscores.
    GameObject[] alphabetArray = new GameObject[10]; //The gameobject array that VISUALLY displays the player text. Relies on underscore position.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTypingActive)
        {
            AcceptInput();
        }
        //print(playerTextInput);
    }

    void AcceptInput() //The method to accept player input. Letters and Backspace/Enter are valid inputs.
    {


        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            print("backspace");
            //remove a letter. (to do: ensure it does not become less than zero)
            if (playerTextInput.Length > 0)
            {
                playerTextInput = playerTextInput.Remove(playerTextInput.Length - 1, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Test whether the player answer equals the cloud answer

        }

        if (playerTextInput.Length < cloudWord.Length)//Ensures that the player may not enter more than the available numbers of letters in the cloud word
        { //All 26 input letters under this if
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerTextInput += 'A';

            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                playerTextInput += 'B';

            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                playerTextInput += 'C';

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerTextInput += 'D';

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerTextInput += 'E';

            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerTextInput += 'F';

            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                playerTextInput += 'G';

            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                playerTextInput += 'H';

            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                playerTextInput += 'I';

            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                playerTextInput += 'J';

            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                playerTextInput += 'K';

            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                playerTextInput += 'L';

            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                playerTextInput += 'M';

            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                playerTextInput += 'N';

            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                playerTextInput += 'O';

            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                playerTextInput += 'P';

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerTextInput += 'Q';

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                playerTextInput += 'R';

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerTextInput += 'S';

            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                playerTextInput += 'T';

            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                playerTextInput += 'U';

            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                playerTextInput += 'V';

            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                playerTextInput += 'W';

            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                playerTextInput += 'X';

            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                playerTextInput += 'Y';

            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerTextInput += 'Z';

            }
        }

        if (Input.anyKeyDown) //If a button is pressed, update the physical text display. More efficient than doing it every update
        {
            UpdatePlayerText();
            if (cloudWord.Length > 0 && cloudWord.Length == playerTextInput.Length)//If the player answer is the same length as the actual answer
            {
                if (cloudWord == playerTextInput) //if the answer is correct
                {
                    WordCorrect();
                }
                else //if the answer is WRONG
                {
                    StartCoroutine(WordWrong());
                }
            }
        }
    }

    public void SetNewWord(string newWord) //Sets the new cloud word
    {
        cloudWord = newWord;
    }

    void SpawnUnderscores(int numberOfUnderscores)//Spawns the VISUAL underscores. Positioning is based on the length of the word. !!NB Change the gap distance and middle position here!!
    {
        Vector3 middleOfWordPos = new Vector3(0, -4.5f, 0); //Where the middle of the word should be on screen
        float gapSpace = 2.4f; //How far one letter is from the next
        if (numberOfUnderscores%2 == 0)//if Even
        {
            middleOfWordPos -= Vector3.right * (numberOfUnderscores / 2 - 1) * gapSpace + Vector3.right * gapSpace * 0.5f; //Set the 'start' position of the first underscore (to be symmetrical)

            for (int i = 0; i < numberOfUnderscores; i++)
            {
                underscoreArray[i] = Instantiate(underscorePrefabArr[Random.Range(0, underscorePrefabArr.Length)], middleOfWordPos + Vector3.right * i * gapSpace, Quaternion.identity);
            }
        }
        else //if Odd
        {
            middleOfWordPos -= Vector3.right * (numberOfUnderscores / 2) * gapSpace; //Set the 'start' position of the first underscore (to be symmetrical)
            for (int i = 0; i < numberOfUnderscores; i++)
            {
                underscoreArray[i] = Instantiate(underscorePrefabArr[Random.Range(0, underscorePrefabArr.Length)], middleOfWordPos + Vector3.right * i * gapSpace, Quaternion.identity);
            }
        }
    }

    void DeleteUnderscores() //Removes the VISUAL underscores from the screen
    {
        for (int i = 0; i < underscoreArray.Length; i++)
        {
            Destroy(underscoreArray[i]);
        }
    }

    public void AllowInput() //Let the player type, AND spawns in the underscores for the word.
    {
        isTypingActive = true;
        SpawnUnderscores(cloudWord.Length);
    }

    public void CancelInput() //Clear word, disable typing, remove underscores;
    {
        isTypingActive = false;
        playerTextInput = "";
        UpdatePlayerText();
        DeleteUnderscores();

    }

    void UpdatePlayerText() //Update the VISUAL player text input. Is dependant on the position of the underscores
    {
        float distanceAboveUnderscore = 1f;
        if (playerTextInput.Length > 0)
        {
            for (int i = 0; i < playerTextInput.Length; i++)
            {
                if (alphabetArray[i] == null)
                {
                    alphabetArray[i] = Instantiate(alphabetPrefabArr[playerTextInput[i] - 65], underscoreArray[i].transform.position + Vector3.up * distanceAboveUnderscore, Quaternion.identity);
                }
            }
            for (int i = playerTextInput.Length; i < alphabetArray.Length; i++)
            {
                if (alphabetArray[i] != null)
                {
                    Destroy(alphabetArray[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < alphabetArray.Length; i++)
            {
                if (alphabetArray[i] != null)
                {
                    Destroy(alphabetArray[i]);
                }
                
            }
        }
    }

    IEnumerator WordWrong() //A coroutine to run when the player gets the word wrong.
    {
        isTypingActive = false;
        ColourAlphabet(1);
        yield return new WaitForSeconds(0.5f);
        playerTextInput = "";
        UpdatePlayerText();
        isTypingActive = true;
        print("Word is WRONG!");
    }

    void WordCorrect() //A method to run when the player gets the word right.
    {
        GameManager.gameManager.AddToScore(1);
        isTypingActive = false;
        //Play ding noise
        ColourAlphabet(2);
        GameObject.Find("CloudSpawnerObj").GetComponent<CloudSpawnerScript>().SpeedUpCloud(5); //Dependant on a CloudSpawnerObject !!NB!! Change the speed value here!
        print("Word is RIGHT!");
        //yield return new WaitForSeconds(0.5f);
    }

    void ColourAlphabet(int choice) //0 for a white alphabet, 1 for a red alphabet, 2 for a green alphabet
    {
        switch (choice)
        {
            case 0: //White colour
            for (int i = 0; i < alphabetArray.Length; i++)
            {
                    if (alphabetArray[i] != null)
                    {
                        alphabetArray[i].GetComponent<SpriteRenderer>().color = Color.white;
                    }
            }
                break;
            case 1: //Red colour
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    if (alphabetArray[i] != null)
                    {
                        alphabetArray[i].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    if (alphabetArray[i] != null)
                    {
                        alphabetArray[i].GetComponent<SpriteRenderer>().color = Color.green;
                    }
                }
                break;
        }
    }

}