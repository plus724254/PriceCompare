import 'Product.dart';

class ProductList {
  List<Product> products = List();

  ProductList({this.products});

  factory ProductList.fromJson(List<dynamic> parsedJson){
    var products = List<Product>();

    products = parsedJson.map((i) => Product.fromJson(i)).toList();

    return ProductList(
      products: products,
    );

  }
}