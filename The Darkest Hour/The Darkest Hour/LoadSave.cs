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
                StreamReader file = new StreamReader(Path.Combine(GameConfigs.PlayerGameFilesLocation,"FirstCharacter.txt"));
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
            catch (Exception exc)
            {
                Console.WriteLine("Oh no!  There was an error!  See details below");
                Console.WriteLine(exc.ToString());
            }
        }

        public void SaveOne(Player myHero)
        {
            try
            {

                if (Directory.Exists(GameConfigs.PlayerGameFilesLocation) == false)
                {
                    Directory.CreateDirectory(GameConfigs.PlayerGameFilesLocation);
                }

                // You need to either use a try/finally statement to ensure the the close/displose is called regardless if there is an error or not.
                // Any objects that are flagged as IDisposable should be wrapped in an using statement (or use try/finally but using is much cleaner
                // code to look at).
                // The is one of the number one mistakes I see junior programmers do that can cause huge headaches in the long run.  What happens 
                // is under load of if the program has been running a load time, you may run into crashes and/or memory leaks.  These are terribly
                // difficult problems to debug. 
                // Please get into the habit of using the using statement on any and all disposable objects (if it has a close method it most likely has a
                // dispose method).  Visual Stuidio will tell you if an object is IDisposable or not when you try to use the using statement on it.
                using (StreamWriter firstCharacterStreamWriter = new StreamWriter(Path.Combine(GameConfigs.PlayerGameFilesLocation, "FirstCharacter.txt")))
                {
                    firstCharacterStreamWriter.WriteLine(myHero.Identifier);
                    firstCharacterStreamWriter.WriteLine(myHero.health);
                    firstCharacterStreamWriter.WriteLine(myHero.maxHealth);
                    firstCharacterStreamWriter.WriteLine(myHero.mainStat);
                    firstCharacterStreamWriter.WriteLine(myHero.critChance);
                    firstCharacterStreamWriter.WriteLine(myHero.critDamage);
                    firstCharacterStreamWriter.WriteLine(myHero.damage);
                    firstCharacterStreamWriter.WriteLine(myHero.level);
                    firstCharacterStreamWriter.WriteLine(myHero.xp);
                    firstCharacterStreamWriter.WriteLine(myHero.requiredXP);
                    firstCharacterStreamWriter.WriteLine(myHero.armor);
                    firstCharacterStreamWriter.WriteLine(myHero.profession);
                    firstCharacterStreamWriter.WriteLine(myHero.isHardCore);
                    firstCharacterStreamWriter.WriteLine(myHero.WeaponsFull);
                    firstCharacterStreamWriter.WriteLine(myHero.ArmorFull);
                    firstCharacterStreamWriter.WriteLine(myHero.AmuletFull);
                    firstCharacterStreamWriter.WriteLine(myHero.HelmetFull);
                    firstCharacterStreamWriter.WriteLine(myHero.PotionsFull);
                    firstCharacterStreamWriter.Close();
                }

                using (StreamWriter firstCharacterInventoryStreamWriter = new StreamWriter(Path.Combine(GameConfigs.PlayerGameFilesLocation, "FirstCharacterInventory.txt")))
                {
                    int i = 0;

                    foreach (Item x in myHero.Inventory)
                    {
                        firstCharacterInventoryStreamWriter.WriteLine(x);
                        //An iteration of what I tried. Tried many things
                        Item selectedItem = myHero.Inventory.ElementAt(i);
                        // You used the file variable from up above.  you should have used your InventoryFile object instead.  The first file variable as already closed.
                        // I went ahead and renamed the character stream writer (note the naming convention) and the inventory stream writer.
                        // using a very generic word (like file) caused you some confusing when writing this code.  I more applicable name
                        // like firstCharacterStreamWriter is very specific and helps keeps these kind of scenarios from happening.
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.name);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.itemType);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.damage);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.strength);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.agility);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.intelligence);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.health);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.goldFind);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.magicFind);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.requiredLevel);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.critChance);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.critDamage);
                        firstCharacterInventoryStreamWriter.WriteLine(selectedItem.worth);
                        i++;
                    }

                    firstCharacterInventoryStreamWriter.Close();
                    Console.WriteLine("Game Save successful\n");
                }
            }
            catch (Exception exc)
            {
                // Please, please, please get out of the habit of writing empty try/catch statements.  You are hiding the error!
                // never hide the error.  Sometimes the problem is fixed and then forget to remove the empty try/catch
                // and then later on it becomes a huge problem to troubleshoot because error messages from that function
                // will never ever be displayed making it extremely difficult to determine an issue.
                // Just say no to emtpy try/catch statement (even temporarily)...just don't get into that bad habit.
                // in most case, you really don't need to use the try/catch statement.  Let the error bubble up and look at it 
                // in Visual Studio.
                // Later on, you learn to use a good error handling routine that will streamline the error message you get from your computer
                // program.
                // See log4net as an examble: http://stackoverflow.com/questions/7089286/correct-way-of-using-log4net
                Console.WriteLine("Oh no!  There was an error!  See details below");
                Console.WriteLine(exc.ToString());
            }
        }
    }
}
    
