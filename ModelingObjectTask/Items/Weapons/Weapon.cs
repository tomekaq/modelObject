
namespace ModelingObjectTask.Items
{
    public class Weapon : Item
    {
        public int Attack { get { return Attack; } set { Attack = value > 0 ? value : 0; } }
        public int Defense { get { return Defense;} set { Defense = value > 0 ? value : 0; } }

       public Weapon() 
       {
           Attack = 1;
           Defense = 1;
       } 
    }
}
