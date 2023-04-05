namespace SucroseRestaurant.Models.Tables
{
    public interface ITableRepository
    {
        Table GetTable(int id);
        IEnumerable<Table> GetTables();
        Table AddTable(Table table);
        Table UpdateTable(Table table);
        Table DeleteTable(Table table);
    }
}
