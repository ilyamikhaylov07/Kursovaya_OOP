namespace kursovaya_OOP.Account
{
    public enum AccountType // Перечисление видов аккаунта
    {
        FoodAccount,
        PCAccount,
        PSAccount
    }
    public class GameClub<T> where T : Account // класс клуба, в котором прописан функционал, использующий тип ограничения аккаунт
    {
        private readonly List<T> accounts = new List<T>(); // массив аккаунтов

        public string Title { get; private set; } // название клуба

        public string Description { get; private set; } // описание

        public GameClub(string title, string description) // конструктор
        {
            this.Title = title;
            this.Description = description;
        }

      
        public void Start(AccountType account, decimal sum, // метод принимающий события
            AccountHandler somePuting,
            AccountHandler someUsingMoney,
            AccountHandler someOpening)
        {
            T NewAccount = null;

            switch (account) // С помощью перечисления, в зависимости от того какой аккаунт создан, происходит создание нового объекта и на каждый счёт начисляется по 300 бонусов
            {
                case AccountType.PCAccount:
                    NewAccount = new PCAccount(sum, 150) as T; // Происходит преобразование от Т к указаному типу, если преобразование не удаётся, то значение будет null
                    break;
                case AccountType.PSAccount:
                    NewAccount = new PSAccount(sum, 350) as T;
                    break;
                case AccountType.FoodAccount:
                    NewAccount = new FoodAccount(sum, 100) as T;
                    break;
            }

            if (NewAccount == null) // если преобразование не получилось, то значение null, идёт проверка, то тогда вбрасывается исключение
                throw new Exception("Ошибка");

            else{
                accounts.Add(NewAccount);
                }


            NewAccount.Puting += somePuting; // установка обработчиков событий
            NewAccount.UsingMoney += someUsingMoney;
            NewAccount.Opening += someOpening;

            NewAccount.OpenOn();
        }

        //поиск счёта по id
        public T? Find_Id(int id)
        {
            for (int i = 0; i < accounts.Count; i++)
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
            if (accounts != null && accounts.Count > 0)
            {
                return accounts[accounts.Count - 1];
            }
            return null;
        }

        public List<T> GetAccounts() // публичный метод для получения аккаунтов из приватного списка
        {
            return accounts;
        }
    }
}
