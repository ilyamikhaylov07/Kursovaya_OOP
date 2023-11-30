namespace kursovaya_OOP.Account
{
    public interface IAccount // Интерфейс для его последующей реализации абстрактным классом аккаунт
    {
        decimal Use(decimal sum); // Использование денег
        void Put(decimal sum); // Положить деньги на счёт

    }
}
