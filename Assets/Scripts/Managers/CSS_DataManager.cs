using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSS_DataManager : MonoBehaviour
{
    //Singleton Class object
    public static CSS_DataManager Instance { get; private set; }

    /*
    0 = block trap
    1 = bear trap
    2 = bomb trap
    3 = clown trap
    4 = nuke trap
    5 = spinning box trap
    6 = fire bomb
    */
    [Header("Data")]
    [SerializeField] public List<CSS_Trap> trapData = new List<CSS_Trap>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
        this.ReadCSVFile();
    }

    public void ReadCSVFile()
    {
        int count = 0; // Skips the first row in the spreadsheet so it doesn't process unrelated information
        int count2 = 0; // The indicator of which element is inside of the row array
        int count3 = 0; // The indicator of where the element should be placed in the list (goes 0, 1, 2, 3, etc. like an array)
        string[] stringArray = File.ReadAllLines("Assets/GameData/Trap_Stats.csv");
        foreach (string line in stringArray)
        {
            if (count != 0) // The first line is hardcoded, hence it skips it so it doesn't process unrelated information
            {
                trapData.Add(new CSS_Trap()); //It creates an instance of the Trap class
                string[] row = line.Split(','); //Seperates each point of data from the spreadsheet into it's own point of data in the string array
                                                //(It's formatted like Block,3,0,0... etc) hence the split function splits each individual stat into
                                                //It's own element in the array
                foreach (string data in row) // For each element in the row...
                {
                    switch (count2)
                    {
                        case 0:
                            {
                                this.trapData[count3].SetName(data);
                                break;
                            }
                        case 1:
                            {
                                this.trapData[count3].SetLifeTime(float.Parse(data));
                                break;
                            }
                        case 2:
                            {
                                this.trapData[count3].SetDamage(int.Parse(data));
                                break;
                            }
                        case 3:
                            {
                                this.trapData[count3].SetTimeLock(float.Parse(data));
                                break;
                            }
                        case 4:
                            {
                                this.trapData[count3].SetTier(int.Parse(data));
                                break;
                            }
                    }
                    count2++;
                }
                count3++;
            }
            count++;
            count2 = 0;
        }

        //Debug message
        foreach (CSS_Trap Data in this.trapData)
        {
            Data.Print(); //Prints the information
        }
    }

    public List<CSS_Trap> GetTrapData()
    {
        return trapData;
    }

}
