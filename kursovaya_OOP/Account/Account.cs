namespace kursovaya_OOP.Account
{
    public abstract class Account : IAccount
    {
        protected internal event AccountHandler Puting; // Событие для зачисления денег на счёт
        protected internal event AccountHandler UsingMoney; // Событие для списания денег
        protected internal event AccountHandler Opening; // Событие для открытия счёта/аккаунта
        
        public decimal Sum { get; private set; } // свойство для суммы на аккаунте
        
        public int Id { get; private set; } // Id аккаунта
        
        static int counter = 0; // счётчик для подсчёта аккаунтов
        
        public Account(decimal sum)
        {
            Sum = sum;
            Id = ++counter; // при создании счётчик обновляется предикатом
        }

        
        
        private void EventChange(EventArgs e, AccountHandler handler)//Вызов событий, в зависимости какое событие туда попадёт
        {
            if (e != null)
                handler?.Invoke(this, e);
        }

        
        
        
        // Вызов для каждого события
        protected virtual void PutOn(EventArgs e)
        {
            EventChange(e, Puting);
        }
        protected virtual void UsingMoneyOn(EventArgs e)
        {
            EventChange(e, UsingMoney);
        }
        protected virtual void OpeningOn(EventArgs e)
        {
            EventChange(e, Opening);
        }

        // реализация интерфеса. Положить деньги
        public virtual void Put(decimal sum)
        {
            Sum += sum;
            PutOn(new EventArgs("На счёт поступило: " + sum, sum));
            Console.WriteLine($"Сумма баланса: {Sum}");
        }

        // реализация интерфеса. Использование денег
        public virtual decimal Use(decimal sum)
        {
            decimal balance = 0;
            if (Sum >= sum)
            {
                Sum -= sum;
                balance = sum;
                UsingMoneyOn(new EventArgs($"Сумма {sum} снята со счёта {Id}", sum));
            }
            else
            {
                UsingMoneyOn(new EventArgs($"Недостаточно денег на счёте {Id}", 0));
            }
            return balance;
        }

        protected internal virtual void OpenOn()
        {
            OpeningOn(new EventArgs($"Поздравляем! Открыт новый счёт. Id счёта: {Id}", Sum));
        }
    }
}
