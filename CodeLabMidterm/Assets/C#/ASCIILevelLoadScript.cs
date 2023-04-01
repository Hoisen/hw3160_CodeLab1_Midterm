using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoadScript : MonoBehaviour
{
    public GameObject player;
    public GameObject wall;
    public GameObject table;
    public GameObject fire;
    public GameObject tablewFire;
    public GameObject enemy;
    public GameObject timer;

    public GameObject currentPlayer;

    private int currentLevel = 0;
    GameObject level;

    private bool triggeredTable = false;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }
    const string FILE_NAME = "LevelNum.txt";
    const string FILE_DIR = "/Levels/";
    string FILE_PATH;

    public float xOffset;

    public float yOffset;

    public Vector2 playerStartPos;
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath +FILE_DIR + FILE_NAME;
        LoadLevel();
    }

    bool LoadLevel()
    {
        Destroy(level);
        level = new GameObject("Level: ");
        string newPath = FILE_PATH.Replace("Num", currentLevel + "");
        //load all the lines of the file into an array of strings
        //string[] fileLines = File.ReadAllLines(FILE_PATH);
        //add newlevel.txt
        string[] fileLines = File.ReadAllLines(newPath);
        
        //for loop to go through each line
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            //get each line out of the array
            string LineText = fileLines[yPos];
            //string fileContents = File.ReadAllText(FILE_PATH);
            //turn the current line into an array of chars
            char[] lineChars = LineText.ToCharArray();

            //loop through
            for (int i = 0; i < lineChars.Length; i++)
            {
                //get the current char
                char c = lineChars[i];
                //make a variable for a new GameObject
                GameObject newObj = null;

                switch (c)
                {
                    case 'p':
                        playerStartPos = new Vector2(i, yPos);
                        newObj = Instantiate<GameObject>(player);
                        currentPlayer = newObj;
                        break;
                    case 'w':
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '^':
                        newObj = Instantiate<GameObject>(fire);
                        break;
                    case 't':
                        newObj = Instantiate<GameObject>(table);
                        break;
                    case 'T':
                        newObj = Instantiate<GameObject>(tablewFire);
                        break;
                    case 'E':
                        newObj = Instantiate<GameObject>(enemy);
                        break;
                    case 'm':
                        newObj = Instantiate<GameObject>(timer);
                        break;
                    default:
                        newObj = null;
                        break;
                }
                
                if (newObj != null)
                {
                    //position it based on where it was
                    //in the file
                    newObj.transform.position = new Vector2(xOffset + i, yOffset -yPos);
                    newObj.transform.parent = level.transform;
                }

                //newObj.transform.position = new Vector2(i, 0);
            }
        }

        return false;
    }

    public void ResetPlayer()
    {
        currentPlayer.transform.position = playerStartPos;
    }

    public void HitDoor()
    {
        Debug.Log("Triggered a door!");
        CurrentLevel++;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
