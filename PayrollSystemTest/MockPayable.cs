namespace PayrollSystem
{
    internal class MockPayable : AbstractPayable
    {
        public override float Pay() { return 200; }
    }
}
