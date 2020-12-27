class Product{
  String imageUrl;
  String pageUrl;
  String name;
  String detail;
  String price;

  Product({
    this.imageUrl,
    this.pageUrl,
    this.name,
    this.detail,
    this.price,
  });

  factory Product.fromJson(Map<String, dynamic> json){
    return Product(
      imageUrl: json['imageUrl'],
      pageUrl: json['pageUrl'],
      name: json['name'],
      detail: json['detail'],
      price: json['price'],
    );
  }

}