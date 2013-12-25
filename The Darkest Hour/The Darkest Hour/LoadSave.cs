using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using System.Data.OleDb;
using System.Data;
using System.IO;
using The_Darkest_Hour.Items_and_Inventory;

namespace The_Darkest_Hour
{
    class LoadSave
    {
        OleDbConnection myConnection;
        OleDbCommandBuilder myCommandBuilder;
        OleDbDataAdapter myDataAdapter;
        DataTable myDataTable = new DataTable();
        int position = 0;

        //public void Load(Player myHero, string providedName)
        //{
        //    try
        //    {
        //        myConnection = new OleDbConnection();
        //        myConnection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\LoadSave.accdb";
        //        myConnection.Open();
        //        myDataAdapter = new OleDbDataAdapter("Select * From Characters", myConnection);
        //        myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);
        //        myDataAdapter.Fill(myDataTable);
        //        myConnection.Close();

        //        myHero.Identifier = myDataTable.Rows[position]["CharacterName"].ToString();
        //        string tempHealth = myDataTable.Rows[position]["Health"].ToString();
        //        myHero.health = Int32.Parse(tempHealth);
        //        myHero.maxHealth = myHero.health;
        //        string tempStat = myDataTable.Rows[position]["MainStat"].ToString();
        //        myHero.mainStat = Int32.Parse(tempStat);
        //        string tempCritChance = myDataTable.Rows[position]["CritChance"].ToString();
        //        myHero.critChance = Int32.Parse(tempCritChance);
        //        string tempCritDamage = myDataTable.Rows[position]["CritDamage"].ToString();
        //        myHero.critDamage = Int32.Parse(tempCritDamage);
        //        string tempDamage = myDataTable.Rows[position]["Damage"].ToString();
        //        myHero.damage = Int32.Parse(tempDamage);
        //        string tempLevel = myDataTable.Rows[position]["Level"].ToString();
        //        myHero.level = Int32.Parse(tempLevel);
        //        string tempXP = myDataTable.Rows[position]["XP"].ToString();
        //        myHero.xp = Int32.Parse(tempXP);
        //        string tempRequiredXP = myDataTable.Rows[position]["RequiredXP"].ToString();
        //        myHero.requiredXP = Int32.Parse(tempRequiredXP);
        //        string tempArmor = myDataTable.Rows[position]["Armor"].ToString();
        //        myHero.armor = Int32.Parse(tempArmor);
        //        myHero.profession = myDataTable.Rows[position]["Class"].ToString();
                
        //        //This begins checking different bool values
        //        //Hard Core Check
        //        string tempHardCore = myDataTable.Rows[position]["HardCore"].ToString();
        //        if (tempHardCore == "True")
        //            myHero.isHardCore = true;
        //        else
        //            myHero.isHardCore = false;

        //        //Weapons Slot Check
        //        string tempWeaponsFull = myDataTable.Rows[position]["WeaponsFull"].ToString();
        //        if (tempWeaponsFull == "True")
        //            myHero.WeaponsFull = true;
        //        else
        //            myHero.WeaponsFull = false;

        //        //Armor Slot Check
        //        string tempArmorFull = myDataTable.Rows[position]["ArmorFull"].ToString();
        //        if (tempArmorFull == "True")
        //            myHero.ArmorFull = true;
        //        else
        //            myHero.ArmorFull = false;

        //        //Amulet Slot Check
        //        string tempAmuletFull = myDataTable.Rows[position]["AmuletFull"].ToString();
        //        if (tempAmuletFull == "True")
        //            myHero.AmuletFull = true;
        //        else
        //            myHero.AmuletFull = false;

        //        //Helmet Slot Check
        //        string tempHelmetFull = myDataTable.Rows[position]["HelmetFull"].ToString();
        //        if (tempHelmetFull == "True")
        //            myHero.HelmetFull = true;
        //        else
        //            myHero.HelmetFull = false;

        //        //Potions Check
        //        string tempPotionsFull = myDataTable.Rows[position]["PotionsFull"].ToString();
        //        if (tempPotionsFull == "True")
        //            myHero.PotionsFull = true;
        //        else
        //            myHero.PotionsFull = false;

        //        //Read in the inventory
        //        //Re-instate the connection because the inventory is stored in a different database
        //        myConnection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\LoadSave.accdb";
        //        myConnection.Open();
        //        myDataAdapter = new OleDbDataAdapter("Select * From Inventory", myConnection);
        //        myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);
        //        myDataAdapter.Fill(myDataTable);
        //        myConnection.Close();




        //    }
        //    catch (Exception e)
        //    {
        //        //Code some error message
        //    }
        //}

        public void LoadOne(Player myHero)
        {
            bool done = false;
            Item item;
            try
            {
                StreamReader file = new StreamReader(@"c:\TheDarkestHour\CharacterSavesAlpha\FirstCharacter.txt");
                myHero.Identifier = file.ReadLine();
                myHero.health = int.Parse(file.ReadLine());
                myHero.maxHealth = int.Parse(file.ReadLine());
                myHero.mainStat = int.Parse(file.ReadLine());
                myHero.critChance = double.Parse(file.ReadLine());
                myHero.critDamage = double.Parse(file.ReadLine());
                myHero.damage = int.Parse(file.ReadLine());
                myHero.level = int.Parse(file.ReadLine());
                myHero.xp = int.Parse(file.ReadLine());
                myHero.requiredXP = int.Parse(file.ReadLine());
                myHero.armor = int.Parse(file.ReadLine());
                myHero.profession = file.ReadLine();
                myHero.isHardCore = bool.Parse(file.ReadLine());
                myHero.WeaponsFull = bool.Parse(file.ReadLine());
                myHero.ArmorFull = bool.Parse(file.ReadLine());
                myHero.AmuletFull = bool.Parse(file.ReadLine());
                myHero.HelmetFull = bool.Parse(file.ReadLine());
                myHero.PotionsFull = bool.Parse(file.ReadLine());

                //while (done == false)
                //{
                //    item = new Item(file.ReadLine());
                //}
            }
            catch (Exception e)
            {
            }
        }

        public void SaveOne(Player myHero)
        {
            try
            {
                if (Directory.Exists(@"c:\TheDarkestHour\CharacterSavesAlpha") == false)
                {
                    Directory.CreateDirectory(@"c:\TheDarkestHour\CharacterSavesAlpha");
                }
                StreamWriter file = new StreamWriter(@"c:\TheDarkestHour\CharacterSavesAlpha\FirstCharacter.txt");

                file.WriteLine(myHero.Identifier);
                file.WriteLine(myHero.health);
                file.WriteLine(myHero.maxHealth);
                file.WriteLine(myHero.mainStat);
                file.WriteLine(myHero.critChance);
                file.WriteLine(myHero.critDamage);
                file.WriteLine(myHero.damage);
                file.WriteLine(myHero.level);
                file.WriteLine(myHero.xp);
                file.WriteLine(myHero.requiredXP);
                file.WriteLine(myHero.armor);
                file.WriteLine(myHero.profession);
                file.WriteLine(myHero.isHardCore);
                file.WriteLine(myHero.WeaponsFull);
                file.WriteLine(myHero.ArmorFull);
                file.WriteLine(myHero.AmuletFull);
                file.WriteLine(myHero.HelmetFull);
                file.WriteLine(myHero.PotionsFull);
                file.Close();

                if (Directory.Exists(@"c:\TheDarkestHour\CharacterSavesAlpha") == false)
                {
                    Directory.CreateDirectory(@"c:\TheDarkestHour\CharacterSavesAlpha");
                }
                StreamWriter inventoryFile = new StreamWriter(@"c:\TheDarkestHour\CharacterSavesAlpha\FirstCharacterInventory.txt");

                string check = "true";
                int i = 0;
                
                foreach (Item x in myHero.Inventory)
                {
                    try
                    {
                        file.WriteLine(x); 
                        //An iteration of what I tried. Tried many things
                        //Item selectedItem = myHero.Inventory.ElementAt(i);
                        //file.WriteLine(selectedItem.name);
                        //file.WriteLine(selectedItem.itemType);
                        //file.WriteLine(selectedItem.damage);
                        //file.WriteLine(selectedItem.strength);
                        //file.WriteLine(selectedItem.agility);
                        //file.WriteLine(selectedItem.intelligence);
                        //file.WriteLine(selectedItem.health);
                        //file.WriteLine(selectedItem.goldFind);
                        //file.WriteLine(selectedItem.magicFind);
                        //file.WriteLine(selectedItem.requiredLevel);
                        //file.WriteLine(selectedItem.critChance);
                        //file.WriteLine(selectedItem.critDamage);
                        //file.WriteLine(selectedItem.worth);
                        //i++;
                    }
                    catch
                    {
                    }
                }

                inventoryFile.Close();
                Console.WriteLine("Game Save successful\n");
            }
            catch (Exception e)
            {
            }
        }
    }
}
