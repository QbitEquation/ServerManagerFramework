namespace ServerManagerFramework
{
    [RequireProgram("javaw.exe")]
    public class MinecraftServer : ServerProcess<NewableString>
    {
        public MinecraftServer(string workingDirectory) : base(workingDirectory, "javaw.exe")
        {
            Arguments.Add("nogui", ArgumentPosition.right);
        }
    }
}
