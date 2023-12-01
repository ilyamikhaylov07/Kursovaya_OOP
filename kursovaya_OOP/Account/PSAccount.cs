using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_OOP.Account
{
    public class PSAccount : Account // аккаунт для консолей, наследуется от абстрактного класса 
    {
        public decimal ServiceCost {  get; set; } // стоимость 
        public PSAccount(decimal sum,  decimal serviceCost) : base(sum) // конструктор, с наследуемой суммой от конструктора абстрактного класса
        {
            ServiceCost = serviceCost;
        }

        protected internal override void OpenOn() // переопределённый метод 
        {
            base.OpeningOn(new EventArgs($"Открыт новый счёт для оплаты тарифов консолей. Id счёта: {this.Id}", this.Sum));
        }

        
    }
}
