using ErrorOr;

namespace BuberBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {

        public static Error InvalidName => Error.Validation(
            code: "breakfast.InvalidName",
            description: "The breakfast name must be at least 3 characters and no more than 50 characters.");
        public static Error InvalidDescription => Error.Validation(
            code: "breakfast.InvaliDescription",
            description: "The breakfast description must be at least 50 characters and no more than 150 characters.");
        public static Error NotFound => Error.NotFound(
            code: "breakfast_not_found",
            description: "The breakfast was not found.");
    }
}