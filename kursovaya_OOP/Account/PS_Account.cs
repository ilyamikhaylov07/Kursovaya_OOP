using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_OOP.Account
{
    internal class PS_Account : Account // аккаунт для консолей, наследуется от абстрактного класса 
    {
        public decimal ServiceCost {  get; set; } // стоимость 
        public PS_Account(decimal sum,  decimal serviceCost) : base(sum) // конструктор, с наследуемой суммой от конструктора абстрактного класса
        {
            ServiceCost = serviceCost;
        }

        protected internal override void OpenOn() // переопределённый метод 
        {
            base.OpeningOn(new EventArgs($"Открыт новый счёт для оплаты тарифов консолей. Id счёта: {this.Id}", this.Sum));
        }

        
    }
}
