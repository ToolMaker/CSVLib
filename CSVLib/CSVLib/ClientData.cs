namespace CSVLib
{
    /// <summary>
    /// Class Structure to contain CLient Data from CSV file
    /// NOTE: I'm not fond of comments as I believe code should be readable and not heavily commented,
    ///         If code is heavily commented then it created maintenace work.
    ///         However if there is a documentation requirment then the subject is debatble
    /// </summary>
    public class ClientData
    {
        public string Address { get; internal set; }

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public string PhoneNumber { get; internal set; }
    }
}