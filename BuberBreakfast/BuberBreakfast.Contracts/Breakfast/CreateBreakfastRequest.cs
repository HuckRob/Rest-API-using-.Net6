namespace BuberBreakfast.Contracts.Breakfast;

    public record CreateBreakfastRequest(
        String Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        List<string> Savory,
        List<string> Sweet

    );
