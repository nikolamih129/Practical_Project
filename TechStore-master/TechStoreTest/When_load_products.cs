using Machine.Specifications;
using System;
using TechStore.UI.Data;
using TechStore.UI.Services;


namespace TechStoreBlazorApp.Shared.TechStoreTest
{
    [Subject( typeof (ProductManager))]
    public class When_load_products
    {
        static Exception exception;
        static DataContext dbContext;
        static ProductManager productManager;

        Establish context = () => { 
            dbContext = new DataContext ();
            productManager = new ProductManager(dbContext);
        };

        Because of = () => exception = Catch.Exception(() => productManager.GetProductDetails());

        It should_fail = () => exception.ShouldBeOfExactType<FieldAccessException>();

        It should_have_a_specific_reason = () => exception.Message.ShouldContain("Unable to load products from database.");
    }
}
