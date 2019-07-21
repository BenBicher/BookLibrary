namespace BLL.Model
{
    public interface IDataBase
    {
        void AddItem(Item item);
        void updateItem(Item item);
        void deleteItem(Item item);

        void ReadItemData();
        void SaveItemData();
        void SaveUsersData();
        void ReadUsersData();
        void AddUser(User user);
    }
}
