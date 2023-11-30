namespace kursovaya_OOP.Account
{
    public class Food_Account : Account // аккаунт для еды, наследуется от абстрактного класса 
    {
        public decimal ServiceCost { get; set; } // стоимость
        
        public Food_Account(decimal sum, decimal serviceCost) : base(sum) // конструктор, с наследуемой суммой от конструктора абстрактного класса
        {
            ServiceCost = serviceCost;
        }


        protected internal override void OpenOn() // переопределённый метод
        {
            base.OpeningOn(new EventArgs($"Открыт новый счёт для оплаты еды. Id счёта: {this.Id}", this.Sum));
        }


    }
}
