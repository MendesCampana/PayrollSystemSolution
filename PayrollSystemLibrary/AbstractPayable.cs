namespace PayrollSystem
{
    public abstract class AbstractPayable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract float Pay();
    }
}