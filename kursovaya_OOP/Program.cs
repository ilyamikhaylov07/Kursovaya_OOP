using kursovaya_OOP;
using System.IO;

namespace kursovaya_OOP.Account;
class Program
{
    static void Main(string[] args)
    {

        /*Происходит приветствие, создаётся новый клуб  */
        Console.WriteLine("Добро пожаловать в мир игр CyberV\n");
        GameClub<Account> CyberV = new GameClub<Account>("CyberV", "Место для ваших игр");

        int work = 1; // переменная для выхода из программы
        while (work > 0) // условие для выхода из программы
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Команда изменения цвета текста
            Console.WriteLine("Выберите действие написав нужную цифру\n");
            Console.WriteLine("1. Создать аккаунт \t 4. Выйти из приложения");
            Console.WriteLine("2. Положить деньги на счёт \t");
            Console.WriteLine("3. Использовать деньги \t");
            Console.ResetColor(); // сброс цвета

            try // блок try / catch для работы приложения, для обработки неправильно нажатой клавишы
            {
                int otvet = Convert.ToInt32(Console.ReadLine()); // записанный ответ

                switch (otvet)
                {
                    case 1:
                        Open(CyberV);
                        break;
                    case 2:
                        Put(CyberV);
                        break;
                    case 3:
                        Use(CyberV);
                        break;
                    case 4:
                        SaveAccounts(CyberV.GetAccounts(), "account.txt");
                        work = 0;
                        continue;
                }
            }
            catch (Exception ex) // обработчик ошибки
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
      
  
    private static void SomeOpening(object sender, EventArgs e) // обработчик открытия счёта
    {
        Console.WriteLine(e.Message);
    }

    private static void SomePuting(object sender, EventArgs e) // обработчик добавления денег на счёт
    {
        Console.WriteLine(e.Message);
    }

    private static void SomeUsingMoney(object sender, EventArgs e) // обработчик траты денег
    {
        Console.WriteLine(e.Message);
    }

    private static void Open(GameClub<Account> club) // метод для создания аккаунта
    {
        Console.WriteLine("Укажите сумму на которую сразу пополните счёт:");

        decimal sum = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Выберите какой аккаунт хотите создать:\n 1. Для оплаты пакетов ПК \n 2. Для оплаты пакетов PS. \n 3. Для оплаты еды");

        AccountType accountType; // переменная перечисления

        int type = Convert.ToInt32(Console.ReadLine());
        if (type == 1)
        {
            accountType = AccountType.PCAccount;
        }
        else if (type == 2)
        {
            accountType = AccountType.PSAccount;
        }
        else
        {
            accountType = AccountType.FoodAccount;
        }
        club.Start(accountType, sum, SomePuting, SomeUsingMoney, SomeOpening); // обработчики событий

        Account createdAccount = club.GetLastCreatedAccount(); // получение последнего созданного аккаунта

        // Проверка баланса
        if (createdAccount != null)
        {
            Console.WriteLine($"Баланс аккаунта {createdAccount.Id}: {createdAccount.Sum}");
        }
        else
        {
            Console.WriteLine("Не удалось получить информацию о созданном аккаунте.");
        }
    }

    // метод использования денег
    private static void Use(GameClub<Account> club)
    {
        Console.WriteLine("Укажите сумму для использования:");

        decimal sum = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Введите id счета:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите сколько вы будете играть - 1 минута = 1 рубль");
        decimal ServiceCost = Convert.ToDecimal(Console.ReadLine());

        club.Use(sum, id, ServiceCost);
    }

    // метод для пополнения аккаунта
    private static void Put(GameClub<Account> club)
    {
        Console.WriteLine("Укажите сумму, чтобы положить на счет:");
        decimal sum = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Введите Id счета:");
        int id = Convert.ToInt32(Console.ReadLine());
        club.Put(sum, id);
    }

    private static void SaveAccounts(List<Account> accounts, string fileName) // Сохранение аккаунтов в файл
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"Id:{account.Id}, Сумма: {account.Sum}, Тип: {account.GetType().Name}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Аккаунты успешно сохраны в файл {fileName}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при сохранении аккаунта{ex.Message}");
        }
    }

}

