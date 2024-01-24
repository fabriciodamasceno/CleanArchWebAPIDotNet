using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id com valor inválido.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido ou requirido");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido. O tamanho minímo é de 3 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição inválida ou requirido");

            DomainExceptionValidation.When(description.Length < 5,
                "Descrição inválido. O tamanho minímo é de 5 caracteres.");
            
            DomainExceptionValidation.When(price < 0,
                "O preço não pode ser menor que zero.");

            DomainExceptionValidation.When(stock < 0,
                "O estoque não pode ser menor que zero.");

            DomainExceptionValidation.When(image.Length > 250,
                "O tamanho máximo da imagem deve ser de 250 caracteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }

        public int CategoryId { get; set; }
        public Product Category { get; set; }
    }
}
