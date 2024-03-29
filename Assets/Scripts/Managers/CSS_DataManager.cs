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
    //[SerializeField] public List<CSS_Trap> trapData = new List<CSS_Trap>();

    public class TrapData
    {
        public int damage;
        public int tier;
        public float lifeTime;
        public float timeLock;
        public string name;

        public TrapData()
        {
            damage = 0;
            tier = 0;
            lifeTime = 0.0f;
            timeLock = 0.0f;
            name = "hi";
        }

        public string Print()
        {
            string printText = "Name: " + name +
                " | Lifetime: " + lifeTime + 
                " | Damage: " + damage + 
                " | Timelock: " + timeLock + 
                " | Tier: " + tier;
            return printText;
        }

        public void SetDamage(int _dmg) { this.damage = _dmg; }
        public void SetTier(int _tier) { this.tier = _tier; }
        public void SetLifeTime(float _life) { this.lifeTime = _life; }
        public void SetTimeLock(float _lock) { this.timeLock = _lock; }
        public void SetName(string _name) { this.name = _name; }
        public int GetDamage() { return damage; }
        public int GetTier() { return tier; }
        public float GetLifeTime() { return lifeTime; }
        public float GetTimeLock() { return timeLock; }
        public string GetName() { return name; }
    }
    public TrapData[] trapData = new TrapData[7];
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
        for (int i = 0; i < trapData.Length; i++)
        {
            trapData[i] = new TrapData();
        }
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
                //trapData.Add(new CSS_Trap()); //It creates an instance of the Trap class
                //trapData = new TrapData[7];
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
        foreach (TrapData Data in this.trapData)
        {
            //Debug.Log(Data.Print()); //Prints the information
        }
    }

    public TrapData[] GetTrapData()
    {
        return trapData;
    }

}
