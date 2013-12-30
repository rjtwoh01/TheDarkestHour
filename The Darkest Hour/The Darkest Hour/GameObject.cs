using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Characters.Professions;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour
{
    // Base object for all objects in the game.
    // Do know if we will need this but it will
    // give a place to place any common methods and
    // properties for all objects if we needed.
    [System.Xml.Serialization.XmlInclude(typeof(Character))]
    [System.Xml.Serialization.XmlInclude(typeof(Player))]
    [System.Xml.Serialization.XmlInclude(typeof(Profession))]
    [System.Xml.Serialization.XmlInclude(typeof(Cleric))]
    [System.Xml.Serialization.XmlInclude(typeof(Guardian))]
    [System.Xml.Serialization.XmlInclude(typeof(Mage))]
    [System.Xml.Serialization.XmlInclude(typeof(Hunter))]
    [System.Xml.Serialization.XmlInclude(typeof(Warrior))]
    [System.Xml.Serialization.XmlInclude(typeof(Player))]
    [System.Xml.Serialization.XmlInclude(typeof(Item))]
    [System.Xml.Serialization.XmlInclude(typeof(Weapon))]
    [System.Xml.Serialization.XmlInclude(typeof(Armor))]
    [System.Xml.Serialization.XmlInclude(typeof(Potion))]
    [System.Xml.Serialization.XmlInclude(typeof(Helmet))]
    [System.Xml.Serialization.XmlInclude(typeof(Amulet))]
    public class GameObject
    {
    }
}
