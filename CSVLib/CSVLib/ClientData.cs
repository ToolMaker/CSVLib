namespace CSVLib
{
    /// <summary>
    /// Class Structure to contain CLient Data from CSV file
    /// </summary>
    public class ClientData
    {
        public string Address { get; internal set; }

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public string PhoneNumber { get; internal set; }
    }
}