namespace dotnet_agenda_de_contatos_mvc.Models
{
    public class Contact
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }    
    }
}