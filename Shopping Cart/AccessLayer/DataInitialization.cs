using System.Collections.Generic;
using System.Data.Entity;
using Shopping_Cart.Models;

namespace Shopping_Cart.AccessLayer
{//DropCreateDatabaseIfModelChanges<ShoppingCartContext>
    public class DataInitialization: DropCreateDatabaseIfModelChanges<ShoppingCartContext>
    {
        protected override void Seed(ShoppingCartContext context)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Tecnologia"
                },
                new Category
                {
                    Name = "Ficção científica"
                },
                new Category
                {
                    Name="Não ficção"
                },
                new Category
                {
                    Name="Literatura inglesa"
                },
            };
            categories.ForEach(c=>context.Categories.Add(c));
            var author = new Author
            {
                Biography = "Um cara muito louco",
                FirstName = "George",
                LastName = "R.R. Martin"
            };
            var books = new List<Book>
            {
                new Book
                {
                    Author = author,
                    Category = categories[0],
                    Description = "Um livro louco das idéias",
                    Featured = true,
                    ImageUrl = "https://omundoimaginariodelais.files.wordpress.com/2013/05/livro_o_festim_4.jpg?w=535",
                    ISBN = "9780553390568",
                    ListPrice = 30.50m,
                    SalePrice = 25.99m,
                    Synopsis = "Tem morte, reviravolta, sexo e dragões",
                    Title = "O Festim dos Corvos"
                },
                new Book
                {
                    Author = author,
                    Category = categories[0],
                    Description = "Mais um livro louco das idéias",
                    Featured = true,
                    ImageUrl = "https://images-submarino.b2w.io/produtos/01/03/item/111021/7/111021710_3GG.jpg",
                    ISBN = "9783764531027",
                    ListPrice = 30.50m,
                    SalePrice = 25.99m,
                    Synopsis = "Tem mais mortes, reviravoltas, sexo e dragões",
                    Title = "A Dança dos Dragões"
                },
                new Book
                {
                    Author = author,
                    Category = categories[0],
                    Description = "Outro livro louco das idéias",
                    Featured = true,
                    ImageUrl = "http://4.bp.blogspot.com/_8gBNFJwKEq0/TFdWsSnJffI/AAAAAAAABvs/wcOHcXOPw3s/s1600/A-Guerra-de-Tronos.jpg",
                    ISBN = "9780553386790",
                    ListPrice = 30.50m,
                    SalePrice = 25.99m,
                    Synopsis = "Tem mais mortes, reviravoltas, sexo e nenhum dragão (ainda)",
                    Title = "Guerra dos Tronos"
                },
                new Book
                {
                    Author = author,
                    Category = categories[0],
                    Description = "Outro livro louco das idéias",
                    Featured = true,
                    ImageUrl = "http://www.extra-imagens.com.br/livros/LivrodeLiteraturaEstrangeira/FiccaoCientifica/306889/3090026/Livro-As-Cronicas-de-Gelo-e-Fogo-A-Furia-dos-Reis-Volume-2-George-R-R-Martin-306889.jpg",
                    ISBN = "9784150116132",
                    ListPrice = 30.50m,
                    SalePrice = 25.99m,
                    Synopsis = "Tem mortes, reviravoltas, sexo e um pouco de dragões",
                    Title = "A Fúria dos Reis"
                },
                new Book
                {
                    Author = author,
                    Category = categories[0],
                    Description = "Outro livro louco das idéias",
                    Featured = true,
                    ImageUrl = "http://www.casasbahia-imagens.com.br/html/conteudo-produto/484/410534/imagens/livro-cronicas-do-gelo-e-fogo-volume-3.jpg",
                    ISBN = "9781514257449",
                    ListPrice = 30.50m,
                    SalePrice = 25.99m,
                    Synopsis = "Tem mortes pra caralho, reviravoltas pra caralho e mais um pouco, putaria total e um pouco de dragões",
                    Title = "A Tormenta de Espadas"
                },
            };
            books.ForEach(b=>context.Books.Add(b));
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}