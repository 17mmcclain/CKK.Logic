using CKK.Logic.Models;

namespace CKK.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldAddProduct()
        {
            //Assemble
            Customer test1 = new Customer();
            ShoppingCart item = new ShoppingCart(test1);
            Product apples = new Product();
            


            //Act
            var expected = item.AddProduct(apples, 7);
            var actual = item.GetProducts().FirstOrDefault();
            //Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldnotaddProduct()
        {
            //Assemble
            Customer test1 = new Customer();
            ShoppingCart item = new ShoppingCart(test1);
            Product apples = new Product();
            apples.SetId(1);
            Product apples2 = new Product();
            apples2.SetId(2);



            //Act
            var expected = item.AddProduct(apples, 7);
            var actual = item.AddProduct(apples2, 10);
            //Assert

            Assert.Equal(expected, actual);
        }

        //    [Fact]
        //    public void ShouldAddProductWrong()
        //    {

        //        //Assemble
        //        Customer customer = new Customer();
        //        ShoppingCart cart = new ShoppingCart(customer);
        //        Product apples = new Product();
        //        int failexpected = 5;

        //        //Act
        //        cart.AddProduct(apples, 3);
        //        int actual = cart.GetProduct(1).GetQuantity();

        //        //Assert
        //        Assert.Equal(failexpected, actual);
        //    }

        //    [Fact]
        //    public void ShouldRemoveProduct()
        //    {
        //        //Assemble
        //        Customer customer = new Customer();
        //        ShoppingCart cart = new ShoppingCart(customer);
        //        Product apples = new Product();
        //        int expected = 3;
        //        cart.AddProduct(apples, 7);

        //        //Act
        //        cart.RemoveProduct(apples, 4);
        //        int actual = cart.GetProduct(1).GetQuantity();

        //        //Assert
        //        Assert.Equal(expected, actual);
        //    }

        //    [Fact]
        //    public void ShouldFailatRemovingProduct()
        //    {
        //        //Assemble
        //        Customer customer = new Customer();
        //        ShoppingCart cart = new ShoppingCart(customer);
        //        Product apples = new Product();
        //        int expected = 0;
        //        cart.AddProduct(apples, 8);

        //        //Act
        //        cart.RemoveProduct(apples, 7);
        //        int actual = cart.GetProduct(1).GetQuantity();

        //        //Assert
        //        Assert.Equal(expected, actual);
        //    }

        //    [Fact]
        //    public void ShouldGetTotal()
        //    {
        //        //Assemble
        //        Customer customer = new Customer();
        //        ShoppingCart cart = new ShoppingCart(customer);

        //        Product product1 = new Product();
        //        product1.SetPrice(1);
        //        cart.AddProduct(product1);

        //        Product product2 = new Product();
        //        product2.SetPrice(2);
        //        cart.AddProduct(product2);

        //        Product product3 = new Product();
        //        product3.SetPrice(3);
        //        cart.AddProduct(product3);
        //        decimal expected = 6;

        //        //Act
        //        decimal actual = cart.GetTotal();

        //        //Assert
        //        Assert.Equal(expected, actual);
        //    }

        //    [Fact]
        //    public void ShouldFailGetTotal()
        //    {
        //        //Assemble
        //        Customer customer = new Customer();
        //        ShoppingCart cart = new ShoppingCart(customer);

        //        Product product1 = new Product();
        //        product1.SetPrice(1);
        //        cart.AddProduct(product1);

        //        Product product2 = new Product();
        //        product2.SetPrice(2);
        //        cart.AddProduct(product2);

        //        Product product3 = new Product();
        //        product3.SetPrice(3);
        //        cart.AddProduct(product3);
        //        decimal expected = 8;

        //        //Act
        //        decimal actual = cart.GetTotal();

        //        //Assert
        //        Assert.Equal(expected, actual);
        //    }
    }
}