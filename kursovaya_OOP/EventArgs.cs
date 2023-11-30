namespace kursovaya_OOP
{
    public class EventArgs //Класс для обработки событий
    {
        public string Message { get; private set; } //Сообщение 
        public decimal Sum { get; private set; } //Сумма, на которую изменился счёт 

        public EventArgs(string message, decimal sum)
        {
            Message = message;
            Sum = sum;
        }
    }
    public delegate void AccountHandler(object sender, EventArgs e);// Делегат, использующийся для создания событий
}
