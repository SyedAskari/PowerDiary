namespace PowerDiary.ChatHistory.Application.Exceptions
{
    public class NotFoundException: ApplicationException
    {
        public NotFoundException(string name, object key): base($"Requested data for {name} ({key}) not found.")
        {

        }
    }
}
