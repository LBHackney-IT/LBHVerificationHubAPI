namespace LBHVerificationHubAPI.UseCases.V1
{
    public class ThrowOpsErrorUseCase
    {
        public static void  Execute()
        {
            throw new TestOpsErrorException();
        }
    }
}