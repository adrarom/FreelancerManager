namespace FreelancerManager.Domain.Clients
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; }
        public string TaxId { get; }
        public string? Email { get; }

        public Client(string name, string taxId, string? email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Name cannot be empty.",
                    nameof(name));
            }

            if (string.IsNullOrWhiteSpace(taxId))
            {
                throw new ArgumentException(
                    "TaxId cannot be empty.",
                    nameof(taxId));
            }

            if (email is not null && string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(
                    "Email cannot be empty or whitespace.",
                    nameof(email));
            }

            Name = name;
            TaxId = taxId;
            Email = email;
            Id = Guid.NewGuid();
        }
    }
}