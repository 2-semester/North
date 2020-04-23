namespace North.Core.Organization
{
    public class OrganizationInfo
    {
        public OrganizationInfo(string id, string name, string definition)
        {
            Id = id;
            Name = name ?? Id;
            Definition = definition;
        }

        public OrganizationInfo(string id) : this(id, null, null) { }
        public OrganizationInfo(string id, string name) : this(id, name, null) { }

        public string Id;
        public string Name;
        public string Definition;
    }
}
