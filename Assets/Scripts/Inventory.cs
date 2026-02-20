using System.Collections.Generic;
public class Inventory
{
    public List<ItemData> items = new List<ItemData>();
    public void addItem(ItemData item)
    {
        if (items.Count < 9)
        {
            items.Add(item);
        }
        else
        {
            //alert inventory full
        }
    }
    public void removeItem(ItemData item)
    {
        items.Remove(item);
    }
}