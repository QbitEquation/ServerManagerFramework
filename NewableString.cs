namespace ServerManagerFramework
{
    public struct NewableString : IHasString
    {
        public string String { get; private set; }

        public void SetString(string str)
        {
            String = str;
        }
    }
}
