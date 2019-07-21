using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BLL.Model
{
    [Serializable]
    public class DataBase: IDataBase
    {
        private static DataBase instance;
        string ItemsDataPath = @"D:\items.txt";
        string UsersDataPath = @"D:\users.txt";
        public static List<Item> Items;
        public static List<User> Users;
        private DataBase()
        {
            Items = new List<Item>();
            Users = new List<User>();
        }

        public static DataBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataBase();
                }
                return instance;
            }
        }

        public void AddItem(Item item)
        {
            ReadItemData();
            if (item == null) return;
            Items.Add(item);
            SaveItemData();
        }

        public void AddUser(User user)
        {
            ReadUsersData();
            if (user == null) return;
            Users.Add(user);
            SaveUsersData();
        }

        public void deleteItem(Item item)
        {
            Items.Remove(item);
        }

        public static Item GetItem(string title)
        {
            Item item = Items.Where(i => i.Title == title).First();
            return item;
        }

        public void ReadItemData()
        {
            string json = File.ReadAllText(ItemsDataPath);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };  
            Items = JsonConvert.DeserializeObject<List<Item>>(json, settings);
        }

        public void ReadUsersData()
        {
            string json = File.ReadAllText(UsersDataPath);
            Users = JsonConvert.DeserializeObject<List<User>>(json);
        }

        public void SaveItemData()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string json = JsonConvert.SerializeObject(Items, settings);
            //write string to file
            File.WriteAllText(ItemsDataPath, json);
        }

        public void SaveUsersData()
        {
            string json = JsonConvert.SerializeObject(Users);
            //write string to file
            File.WriteAllText(UsersDataPath,json);
        }

        public  void updateItem(Item item)
        {
            
        }
    }
}
