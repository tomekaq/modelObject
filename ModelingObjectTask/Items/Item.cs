
using System.Text;
namespace ModelingObjectTask.Items
{
    public abstract class Item
    {
        protected string name;
        protected int price;
        protected int weight;

        public string Name { get { return name; } set { name = value; } }
        public int Price { get { return price; } set { price = (value> 0? value: 0); } }
        public int Weight { get { return weight; } set { weight = (value > 0 ? value : 0);; } }

        public virtual void Apply(Hero hero) { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
<<<<<<< HEAD
            sb.AppendFormat("Typ: {0} ", this.GetType().Name);
            sb.AppendFormat("Nazwa: {0} ", this.Name);
            sb.AppendFormat("Cena: {0} ", this.Price);
            sb.AppendFormat("Waga: {0} ", this.Weight);
=======
            sb.AppendFormat("Nazwa: {0} ", this.Name);
            sb.AppendFormat("Cena: {0} ", this.Price);
            sb.AppendFormat("Waga: {0} ", this.Weight);

>>>>>>> 4654feb3fbe077952db050b3dc3d6d521320cf1a
            return sb.ToString();
        }
    
    }
}
