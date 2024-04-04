using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>{ 
            new Product{ProductId = 1, CategoryId = 1, ProductName ="Bardak", UnitPrice = 15, UnitsInStock = 15, },
            new Product{ProductId = 2, CategoryId = 1, ProductName ="Kamera", UnitPrice = 500, UnitsInStock = 3, },
            new Product{ProductId = 3, CategoryId = 2, ProductName ="Telefon", UnitPrice = 1500, UnitsInStock = 2, },
            new Product{ProductId = 4, CategoryId = 2, ProductName ="Klavye", UnitPrice = 150, UnitsInStock = 65, },
            new Product{ProductId = 5, CategoryId = 2, ProductName ="Fare", UnitPrice = 85, UnitsInStock = 1, }            
            };
        }

    
        
        public void Add(Product product)
        {
            _products.Add(product);
        }


        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(x => x.CategoryId == CategoryId).ToList();            
        }

        public void Update(Product product)
        {
            Product updateToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updateToProduct.ProductName = product.ProductName;
            updateToProduct.UnitPrice = product.UnitPrice;
            updateToProduct.ProductName= product.ProductName;
            updateToProduct.UnitsInStock= product.UnitsInStock;
            updateToProduct.CategoryId= product.CategoryId;            
        }

        public void Delete(Product entity)
        {
            Product deletedProdurt = _products.SingleOrDefault(p => p.ProductId==entity.ProductId);
            _products.Remove(deletedProdurt);
        }

        Product IEntityRepository<Product>.Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        List<Product> IEntityRepository<Product>.GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
