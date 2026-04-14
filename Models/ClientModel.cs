namespace trabajo_de_SF2.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Service { get; set; }
        public string? ServiceIcon { get; set; }
        public string? AdminEmail { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class ClientFormModel
    {
        public string? CompanyName { get; set; }
        public string? PrincipalService { get; set; }
        public string? AdminEmail { get; set; }
    }

    public class ClientsPageModel
    {
        public List<ClientModel>? Clients { get; set; }
        public int TotalClients { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? FilterService { get; set; }
    }
}
