namespace kursovaya_OOP.Account
{
    public enum AccountType // Перечисление видов аккаунта
    {
        Food_Account,
        PC_Account,
        PS_Account
    }
    public class GameClub<T> where T : Account // класс клуба, в котором прописан функционал, использующий тип ограничения аккаунт
    {
        T[] accounts; // массив аккаунтов

        public string Title { get; private set; } // название клуба

        public string Description { get; private set; } // описание

        public GameClub(string title, string description) // конструктор
        {
            this.Title = title;
            this.Description = description;
        }

        public void Start(AccountType account, decimal sum, // метод принимающий события
            AccountHandler SomePuting,
            AccountHandler SomeUsingMoney,
            AccountHandler SomeOpening)
        {
            T NewAccount = null;

            switch (account) // С помощью перечисления, в зависимости от того какой аккаунт создан, происходит создание нового объекта и на каждый счёт начисляется по 300 бонусов
            {
                case AccountType.PC_Account:
                    NewAccount = new PC_Account(sum, 150) as T; // Происходит преобразование от Т к указаному типу, если преобразование не удаётся, то значение будет null
                    break;
                case AccountType.PS_Account:
                    NewAccount = new PS_Account(sum, 350) as T;
                    break;
                case AccountType.Food_Account:
                    NewAccount = new Food_Account(sum, 100) as T;
                    break;
            }

            if (NewAccount == null) // если преобразование не получилось, то значение null, идёт проверка, то тогда вбрасывается исключение
                throw new Exception("Ошибка");

            else if (accounts == null) // если массив пуст, то добавляется новый аккаунт
                accounts = new T[] { NewAccount };
            else
            {
                T[] values = new T[accounts.Length + 1]; // создаётся временный массив values
                for (int i = 0; i < accounts.Length; i++) // идёт проходка по массиву accounts
                    values[i] = accounts[i]; // идёт сдвиг аккаунта
                values[accounts.Length - 1] = NewAccount; // и второму аккаунту присваивается значения
                accounts = values;

            }

            NewAccount.Puting += SomePuting; // установка обработчиков событий
            NewAccount.UsingMoney += SomeUsingMoney;
            NewAccount.Opening += SomeOpening;

            NewAccount.OpenOn();
        }

        //поиск счёта по id
        public T? Find_Id(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id) return accounts[i];
            }
            return null;
        }
         // метод использования денег на услугу
        public void Use(decimal sum, int id, decimal ServiceCost)
        {
            T account = Find_Id(id);
            if (account == null)
                throw new Exception("счёт не найден");
            else if (sum - ServiceCost >= 0)
                account.Use(ServiceCost);
            else throw new Exception("Недостаточно денег на счёте");

        }

        // метод добавления денег на аккаунт
        public void Put(decimal sum, int id)
        {
            T account = Find_Id(id);
            if (account == null) throw new Exception("Счёт не найден");
            account.Put(sum);
        }

        // Метод который возвращает последний, созданный аккаунт
        public T GetLastCreatedAccount() 
        {
            if (accounts != null && accounts.Length > 0)
            {
                return accounts[accounts.Length - 1];
            }

            return null;
        }

    }
}
