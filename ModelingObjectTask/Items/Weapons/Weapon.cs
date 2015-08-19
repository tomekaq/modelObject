
namespace ModelingObjectTask.Items
{
    public class Weapon : Item
    {
       public int Attack { get; set; }
       public int Defense { get; set; }

       public Weapon() 
       {
           Attack = 1;
           Defense = 1;
       } 
    }
}
