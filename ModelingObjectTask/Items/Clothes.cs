
namespace ModelingObjectTask.Items
{
    public abstract class Clothes:Item
    {
        public int Defense { get { return this.Defense; } set { this.Defense = (value > 0 ? value : 0); } }

        public Clothes()
        {
            Defense = 1;
        }
    }
}
