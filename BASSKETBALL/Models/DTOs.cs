namespace BASSKETBALL.Models
{
    public class DTOs
    {
        public record playerPut (string name, int weight, int height);
        public record playerPost (string name, int weight, int height);
        public record matchData(DateTime be, DateTime ki, int proba, int goal, int fault, Guid playerId);
        public record updateData(DateTime be, DateTime ki, int proba, int goal, int fault);
    }
}
