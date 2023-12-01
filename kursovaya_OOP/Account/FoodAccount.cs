namespace kursovaya_OOP.Account
{
    public class FoodAccount : Account // аккаунт для еды, наследуется от абстрактного класса 
    {
        public decimal ServiceCost { get; set; } // стоимость
        
        public FoodAccount(decimal sum, decimal serviceCost) : base(sum) // конструктор, с наследуемой суммой от конструктора абстрактного класса
        {
            ServiceCost = serviceCost;
        }


        protected internal override void OpenOn() // переопределённый метод
        {
            base.OpeningOn(new EventArgs($"Открыт новый счёт для оплаты еды. Id счёта: {this.Id}", this.Sum));
        }


    }
}
