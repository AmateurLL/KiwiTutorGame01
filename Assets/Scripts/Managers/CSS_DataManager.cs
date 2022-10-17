using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSS_DataManager : MonoBehaviour
{
    List<CSS_Trap> TrapData = new List<CSS_Trap>();
    int count = 0; // Skips the first row in the spreadsheet so it doesn't process unrelated information
    int count2 = 0; // The indicator of which element is inside of the row array
    int count3 = 0; // The indicator of where the element should be placed in the list (goes 0, 1, 2, 3, etc. like an array)


    public void ReadCSVFile()
    {
        string[] stringArray = File.ReadAllLines("csv_test_1.csv");
        foreach (string line in stringArray)
        {
            if (count != 0) // The first line is hardcoded, hence it skips it so it doesn't process unrelated information
            {
                TrapData.Add(new CSS_Trap()); //It creates an instance of the Trap class
                string[] row = line.Split(','); //Seperates each point of data from the spreadsheet into it's own point of data in the string array
                                                //(It's formatted like Block,3,0,0... etc) hence the split function splits each individual stat into
                                                //It's own element in the array
                foreach (string data in row) // For each element in the row...
                {
                    switch (count2)
                    {
                        case 0:
                            {
                                TrapData[count3].trapName = data;
                                break;
                            }

                        case 1:
                            {
                                TrapData[count3].lifeTime = float.Parse(data);
                                break;
                            }

                        case 2:
                            {
                                TrapData[count3].damage = int.Parse(data);
                                break;
                            }

                        case 3:
                            {
                                TrapData[count3].timeLock = float.Parse(data);
                                break;
                            }
                    }

                    //Console.Write(row + " ");
                    count2++;
                }
                count3++;
                //Console.Write("\n");
            }
            count++;
            count2 = 0;
        }
        foreach (CSS_Trap Data in TrapData)
        {
            Data.Print(); //Prints the information
        }
    }

}
