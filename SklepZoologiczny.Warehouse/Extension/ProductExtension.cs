﻿using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Extension
{
    public static class ProductExtension
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price,
                CategorieId = product.CategorieId,
                SupplierId=product.SupplierId,

            };
        }
    }

    public static class ProductDtoExtension
    {
        public static Product ToEntity(this ProductDto product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                SupplierId = product.SupplierId,
                CategorieId = product.CategorieId,
            };
        }
    }

    public static class CreateProductDtoExtension
    {
        public static Product ToEntity(this CreateProductDto product)
        {
            return new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Id = product.Id,
                SupplierId = product.SupplierId,
                CategorieId = product.CategorieId,
                
            };
        }
        public static ProductDto ProductDto(this CreateProductDto product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CategorieId = product.CategorieId,
                SupplierId = product.SupplierId,
                Id= product.Id
            };
        }
    }

}
