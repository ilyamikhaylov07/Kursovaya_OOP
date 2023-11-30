﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_OOP.Account
{
    internal class PC_Account : Account // аккаунт для ПК, наследуется от абстрактного класса 
    {
        public decimal ServiceCost { get; set; } // стоимость 
        public PC_Account(decimal sum, decimal serviceCost) : base(sum) // конструктор, с наследуемой суммой от конструктора абстрактного класса
        {
            this.ServiceCost = serviceCost;
        }

        protected internal override void OpenOn() // переопределённый метод
        {
            base.OpeningOn(new EventArgs($"Открыт новый счёт для оплаты тарифов компьютеров. Id счёта: {this.Id}", this.Sum));
        }

        
       
    }
}
