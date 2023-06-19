﻿using Machine.Specifications;
using System;
using TechStore.UI.Data;
using TechStore.UI.Models;
using TechStore.UI.Services;


namespace TechStoreBlazorApp.Shared.TechStoreTest
{
    [Subject(typeof(ProductManager))]
    public class When_add_product_with_null_model
    {
        static Exception exception;
        static DataContext dbContext;
        static ProductManager productManager;
        static Product product;

        Establish context = () => {
            product = new Product(5, "none", null, "none", "none", "1234");
            dbContext = new DataContext();
            productManager = new ProductManager(dbContext);
        };

        Because of = () => exception = Catch.Exception(() => productManager.AddProduct(product));

        It should_fail = () => exception.ShouldBeOfExactType<ArgumentNullException>();

        It should_have_a_specific_reason = () => exception.Message.ShouldContain("Value cannot be null. (Parameter 'Value 'Model' cannot be null.')");
    }
}
