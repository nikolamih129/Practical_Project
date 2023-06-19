using Machine.Specifications;
using System;
using TechStore.UI.Data;
using TechStore.UI.Models;
using TechStore.UI.Services;


namespace TechStoreBlazorApp.Shared.TechStoreTest
{
    [Subject(typeof(ProductManager))]
    public class When_add_product
    {
        static Exception exception;
        static DataContext dbContext;
        static ProductManager productManager;
        static Product product;

        Establish context = () => {
            product = new Product(5, "none", "none", "none", "none", "1234");
            dbContext = new DataContext();
            productManager = new ProductManager(dbContext);
        };

        Because of = () => exception = Catch.Exception(() => productManager.AddProduct(product));

        It should_fail = () => exception.ShouldBeOfExactType<InvalidOperationException>();

        It should_have_a_specific_reason = () => exception.Message.ShouldContain("No database provider has been configured for this DbContext. A provider can be configured by overriding the 'DbContext.OnConfiguring' method or by using 'AddDbContext' on the application service provider. If 'AddDbContext' is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.");
    }
}
