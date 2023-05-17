namespace Testing_project.Services
{
    public class TestSingletonService : ITestSingeltonServicecs
    {
        private readonly ITestScopedService scop;
        private readonly ITestTransientService trans;

        public TestSingletonService(ITestScopedService scop, ITestTransientService trans)
        {
            this.scop = scop;
            this.trans = trans;
        }

        public string GetData()
        {
            var jet = scop.test;
            var man = trans.test;

            scop.test = 20;
            trans.test = 20;

            return $"Welcome, To Test Project{scop.test} and {trans.test}";
        }
    }
}
