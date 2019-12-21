namespace P04_PizzaCalories.Exceptions
{
	public static class ExceptionMessage
	{
		public static string InvalidDoughException = "Invalid type of dough.";

		public static string DoughWeightOutOfRangeException = "Dough weight should be in the range [1..200].";

		public static string InvalidToppingException = "Cannot place {0} on top of your pizza.";

		public static string ToppingOutOfRangeException = "{0} weight should be in the range [1..50].";

		public static string PizzaNameOutOfRangeException = "Pizza name should be between 1 and 15 symbols.";

		public static string PizzaToppingsOutOfRangeException = "Number of toppings should be in range [0..10].";
	}
}
