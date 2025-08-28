using CategoryProduct.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace CategoryProduct.Models;

[ModelMetadataType(typeof(ProductMetadata))]
public partial class Product
{
}

