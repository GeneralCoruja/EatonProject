namespace EatonAPI.Dtos;

public class EnumeratedResult<T>
{
    public List<T> Items { get; set; }
    public int Count { get; set; }
    
    public EnumeratedResult(List<T> items)
    {
        Items = items.ToList();   
        Count = Items.Count;
    }
}