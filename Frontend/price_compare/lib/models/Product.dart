class Product{
  String imageUrl;
  String pageUrl;
  String webSiteName;
  String name;
  String detail;
  int price;

  Product({
    this.imageUrl,
    this.pageUrl,
    this.webSiteName,
    this.name,
    this.detail,
    this.price,
  });

  factory Product.fromJson(Map<String, dynamic> json){
    return Product(
      imageUrl: json['imageUrl'],
      pageUrl: json['pageUrl'],
      webSiteName: json['webSiteName'],
      name: json['name'],
      detail: json['detail'],
      price: json['price'],
    );
  }

}